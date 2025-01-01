using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;

[System.Serializable]
public struct VentStruct
    {
        public Vector2 position;
        public float goRightChance;
        public float goLeftChance;
        public float goUpChance;
        public float goDownChance;

        // Constructor for the struct
        public VentStruct(Vector2 Postion, float GoRightChance, float GoLeftChance, float GoUpChance, float GoDownChance)
        {
            position = Postion;
            goRightChance = GoRightChance;
            goLeftChance = GoLeftChance;
            goUpChance = GoUpChance;
            goDownChance = GoDownChance;
        }
    }
 
public class FFPSAI : MonoBehaviour 
{

    // Delegate for when a Animatronics position changes
    public delegate void AnimatronicUpdate(int Animatronic);

    // Create an event using the delegate
    public static event AnimatronicUpdate OnAnimatronicUpdate;

    // Delegate for when a Animatronics position changes is finished
    public delegate void FinishAnimatronicUpdate(int Animatronic);

    // Create an event using the delegate
    public static event FinishAnimatronicUpdate OnFinishAnimatronicUpdate;

    // Delegate for when a Animatronics position changes to a certain tile  BTW EXCLUDE LEFTY IT HAS NO VOICE LINES
    public delegate void PlayAnimatronicVoiceline(int Animatronic);

    // Create an event using the delegate
    public static event PlayAnimatronicVoiceline OnPlayAnimatronicVoiceline;

    // Delegate for when a Interval triggers
    public delegate void IntervalTrigger();

    // Create an event using the delegate
    public static event IntervalTrigger OnIntervalTrigger;

    // Delegate for when a Flashlight Interval triggers
    public delegate void FlashlightIntervalTrigger();

    // Create an event using the delegate
    public static event FlashlightIntervalTrigger OnFlashlightIntervalTrigger;

    // Delegate for when a Interval triggers
    public delegate void JumpscareTrigger(int Animatronic);

    // Create an event using the delegate
    public static event JumpscareTrigger OnJumpscareTrigger;

    public int[] AI; // 3=Lefty, 1=Scrap Baby, 2=William Afton, 0=Molten Freddy  // Molten Freddy Should ALLWAYS be 1
    public int[] AIPlayerCounters;
    public Vector2[] AIPositions;
    public int Chance = 4; // 1 in 3 if ai is 1
    public float Interval; //Monday = 8s Tuesday = 5s Wednesday = 4s Thursday = 3s Friday = 2.5s Saturday = 2s
    public float FlashlightInterval = 4f;
    public Vector2[] StartPositions = new Vector2[4] { new Vector2(0, 0), new Vector2(2, 0), new Vector2(6, 0), new Vector2(8, 0) };
    public Vector2 PlayerPosition = new Vector2(4,4);
    public VentStruct[] Vents;
    public float AudioLureChance = 0.5f; //50% Chance
    public Vector2 ActiveAudioLure;
    public bool AudioLureActive;
    public Night night;

    [HideInInspector]
    public bool PlayerLooking;
    [HideInInspector]
    public bool PlayerLookingRight;

    private float GlobalNightTime;
    private float IntervalTimer;
    private float FlashlightIntervalTimer;

    private bool IntervalPaused;
    private bool canJumpscare = true;

    public bool[] EventsTriggers; // 0=MoltenFreddyTP 1=ScrapbabyTP 2=LeftyTP 3=WilliamAftonTP

    public bool[] EventsTriggersLeftSide; // 0=MoltenFreddyTP 1=ScrapbabyTP 2=LeftyTP 3=WilliamAftonTP

    public bool[] EventsTriggersRightSide; // 0=MoltenFreddyTP 1=ScrapbabyTP 2=LeftyTP 3=WilliamAftonTP

    public float chanceOfBeingHeard = 0.1f;

    private string lastNightActiveUse;
    
	void Start () 
    {
        OnIntervalTrigger += IntervalTriggered;
        OnFlashlightIntervalTrigger += FlashlightIntervalTriggered;
        for (int i = 0; i < AI.Length; i++)
        {
            AIPositions[i] = StartPositions[i];
        }
	}
	
	void Update () 
    {
        GlobalNightTime += Time.deltaTime;
        if (!IntervalPaused)
        {
            IntervalTimer += Time.deltaTime;
        }

        if (PlayerLooking)
        {
            FlashlightIntervalTimer += Time.deltaTime;
        }

        if (FlashlightIntervalTimer >= FlashlightInterval)
        {
            FlashlightIntervalTimer = 0f;
            OnFlashlightIntervalTrigger();
        }

        if (IntervalTimer >= Interval)
        {
            OnIntervalTrigger();
            IntervalTimer = 0f;
        }

        HandleNightFunctions();
	}

    void HandleNightFunctions()
    {
        if (lastNightActiveUse != night.activeuse)
        {
            string last = lastNightActiveUse;
            lastNightActiveUse = night.activeuse;
            OnActiveUseSwitch(night.activeuse, last);
        }
    }

    void OnActiveUseSwitch(string newUse, string previous)
    {
        if (newUse == "task")
        {
            chanceOfBeingHeard += 0.2f;
        }

        if (newUse == "none" && previous == "task")
        {
            chanceOfBeingHeard -= 0.2f;
        }
    }

    private void OffIntervalEvents()
    {
        for (int i = 0; i < AI.Length; i++)
        {
            if (AIPositions[i] == new Vector2(2,-4) && (PlayerLookingRight || !PlayerLooking)) // Left Side (Player isnt looking at left side)
            {
                if (CanBeHeard())
                {
                    if (canJumpscare && OnJumpscareTrigger != null)
                    {
                        canJumpscare = false;
                        IntervalPaused = true;
                        OnJumpscareTrigger(i);
                    }
                }
            }
            else if (AIPositions[i] == new Vector2(6,-4) && (!PlayerLookingRight || !PlayerLooking)) // Left Side (Player isnt looking at left side)
            {
                if (CanBeHeard())
                {
                    if (canJumpscare && OnJumpscareTrigger != null)
                    {
                        canJumpscare = false;
                        IntervalPaused = true;
                        OnJumpscareTrigger(i);
                    }
                }
            }
        }
    }

    private void IntervalTriggered()
    {
        for (int i = 0; i < AI.Length; i++)
        {
            if (MovementOppertunity(AI[i]))
            {
                AnimatronicUpdateTriggered(i);
                if (OnAnimatronicUpdate != null)
                {
                    OnAnimatronicUpdate(i);
                }
            }
        }
    }

    private void FlashlightIntervalTriggered()
    {
        for (int i = 0; i < AI.Length; i++)
        {
            Vector2 newPosition;
            if (PlayerLooking)
            {
                if (!CanBeHeard())
                {
                    if (PlayerLookingRight && (AIPositions[i] == new Vector2(2,-4) || AIPositions[i] == new Vector2(2,-4)))
                    {
                        newPosition = StartPositions[i];
                    }
                    else if (!PlayerLookingRight && (AIPositions[i] == new Vector2(6,-4) || AIPositions[i] == new Vector2(6,-4)))
                    {
                        newPosition = StartPositions[i];
                    }
                    else if (PlayerLookingRight && (AIPositions[i] == new Vector2(6,-4) || AIPositions[i] == new Vector2(6,-4)))
                    {
                        newPosition = new Vector2(6,2);
                    }
                    else if (!PlayerLookingRight && (AIPositions[i] == new Vector2(2,-4) || AIPositions[i] == new Vector2(2,-4)))
                    {
                        newPosition = new Vector2(2,2);
                    }
                    else
                    {
                        newPosition = AIPositions[i];
                    }
                }
                else
                {
                    if (PlayerLookingRight && AIPositions[i] == new Vector2(2,-4))
                    {
                        newPosition = new Vector2(0,4);
                    }
                    else if (!PlayerLookingRight && AIPositions[i] == new Vector2(6,-4))
                    {
                        newPosition = new Vector2(8,4);
                    }
                    else
                    {
                        newPosition = AIPositions[i];
                    }
                }
                AIPositions[i] = newPosition;
            }
        }
    }

    private bool CanBeHeard()
    {
        if (chanceOfBeingHeard >= UnityEngine.Random.value)
        {
            return true;
        }
        return false;
    }

    private bool MovementOppertunity(int AILevel)
    {
        // Randomly pick a number between 1 and Chances value
        int randomValue = UnityEngine.Random.Range(1, Chance); // 1 to 3 (exclusive of 4) (Chance should allways be 4)

        //self explanitory :troll:
        if (randomValue <= AILevel)
        {
            return true;  // Success :yay:
        }
        else
        {
            return false; // Failure :boowomp:
        }
    }

    private void AnimatronicUpdateTriggered(int Animatronic)
    {
        VentStruct currentVent = GetVentStruct(AIPositions[Animatronic]);
        Vector2 newPosition = GetNewAnimatronicPosition(currentVent, Animatronic);
        if (PlayerLooking)
        {
            if (!CanBeHeard())
            {
                if (PlayerLookingRight && (AIPositions[Animatronic] == new Vector2(2,-4) || AIPositions[Animatronic] == new Vector2(2,-4)))
                {
                    newPosition = AIPositions[Animatronic];
                }
                else if (!PlayerLookingRight && (AIPositions[Animatronic] == new Vector2(6,-4) || AIPositions[Animatronic] == new Vector2(6,-4)))
                {
                    newPosition = AIPositions[Animatronic];
                }
            }
            else
            {
                if (PlayerLookingRight && AIPositions[Animatronic] == new Vector2(2,-4))
                {
                    newPosition = AIPositions[Animatronic];
                }
                else if (!PlayerLookingRight && AIPositions[Animatronic] == new Vector2(6,-4))
                {
                    newPosition = AIPositions[Animatronic];
                }
            }
        }
        if (IsInRangeOf(currentVent, ActiveAudioLure) && AudioLureActive)
        {
            if (Random.value < (AudioLureChance))
            {
                newPosition = ActiveAudioLure;
            }
        }
        AIPositions[Animatronic] = newPosition;
        Debug.Log(GetAnimatronicName(Animatronic) + " has moved to: "+newPosition.ToString());
        if (newPosition == PlayerPosition)
        {
            Debug.Log("Attempted Jumpscare By: "+GetAnimatronicName(Animatronic));
            if (OnJumpscareTrigger != null && canJumpscare)
            {
                OnJumpscareTrigger(Animatronic);
                canJumpscare = false;
                IntervalPaused = true;
            }
        }

        if (GlobalNightTime >= 60f && AIPositions[Animatronic] == new Vector2(2,-4) && OnPlayAnimatronicVoiceline != null && !EventsTriggersLeftSide[Animatronic])
        {
            EventsTriggersLeftSide[Animatronic] = false;
            OnPlayAnimatronicVoiceline(Animatronic);
        }

        if (GlobalNightTime >= 60f && AIPositions[Animatronic] == new Vector2(6,-4) && OnPlayAnimatronicVoiceline != null && !EventsTriggersRightSide[Animatronic])
        {
            EventsTriggersRightSide[Animatronic] = false;
            OnPlayAnimatronicVoiceline(Animatronic);
        }

        if (OnFinishAnimatronicUpdate != null)
        {
            OnFinishAnimatronicUpdate(Animatronic);
        }
    }

    private VentStruct GetVentStruct(Vector2 Position)
    {
        foreach (VentStruct ventStruct in Vents)
        {
            if (ventStruct.position == Position)
            {
                return ventStruct;
            }
        }

        return new VentStruct(new Vector2(-1,-1), 0f, 0f, 0f, 0f);
    }

    private Vector2 GetNewAnimatronicPosition(VentStruct currentVent, int Anim)
    {
    Vector2[] restrictedPositions = new Vector2[]
    {
        new Vector2(1, 0), new Vector2(3, 0), new Vector2(5, 0), new Vector2(7, 0),
        new Vector2(1, 2), new Vector2(7, 2), new Vector2(1, 4), new Vector2(7, 4),
        new Vector2(0, 1), new Vector2(2, 1), new Vector2(6, 1), new Vector2(8, 1),
        new Vector2(0, 3), new Vector2(2, 3), new Vector2(6, 3), new Vector2(8, 3), new Vector2(4, -2)
    };

    Vector2 newPosition;
    bool isRestrictedPosition;

    do
    {
        float randomRoll = UnityEngine.Random.Range(0f, 101f);

        if (randomRoll <= currentVent.goLeftChance)
        {
            // Move left
            newPosition = AIPositions[Anim] + new Vector2(-2, 0);
        }
        else if (randomRoll <= currentVent.goLeftChance + currentVent.goRightChance)
        {
            // Move right
            newPosition = AIPositions[Anim] + new Vector2(2, 0);
        }
        else if (randomRoll <= currentVent.goLeftChance + currentVent.goRightChance + currentVent.goUpChance)
        {
            // Move up
            newPosition = AIPositions[Anim] + new Vector2(0, 2);
        }
        else if (randomRoll <= currentVent.goLeftChance + currentVent.goRightChance + currentVent.goUpChance + currentVent.goDownChance)
        {
            // Move down
            newPosition = AIPositions[Anim] + new Vector2(0, -2);
        }
        else
        {
            // No movement, return the same position if the chances are 0 or something went wrong
            newPosition = AIPositions[Anim];
        }

        // Check if the new position is in the restricted positions
        isRestrictedPosition = Array.Exists(restrictedPositions, pos => pos == newPosition);

        // If the new position is restricted, update AIPositions[Anim] and reroll
        if (isRestrictedPosition)
        {
            AIPositions[Anim] = newPosition; // Update the current position to the restricted one
        }

    } while (isRestrictedPosition); // Continue looping until a non-restricted position is found

    return newPosition; // Return the valid new position
    }

    private bool IsInRangeOf(VentStruct vent, Vector2 position)
    {
        // Complex math
        Vector2 diff = vent.position - position;

        // Complex math
        if ((Mathf.Abs(diff.x) == 1 && diff.y == 0) || (Mathf.Abs(diff.y) == 1 && diff.x == 0))
        {
            // Complex math
            return true;
        }

    // Complex math
    return false;
    }

    private string GetAnimatronicName(int Animatronic)
    {
        switch (Animatronic)
        {
            case 0:
            return "Molten Freddy";
            break;
            case 1:
            return "Scrap Baby";
            break;
            case 2:
            return "Lefty";
            break;
            case 3:
            return "William Afton";
            break;
        }

        return "Erm, did you add a fith animatronic? What the Sigma!!";
    }

    private void NightEvents(int Animatronic)
    {
        if (Animatronic == 0) //Molten Freddy
        {
            if (GlobalNightTime >= 10f && EventsTriggers[0] == false && AIPositions[0] == new Vector2(4,0))
            {
                EventsTriggers[0] = true;
                AIPositions[0] = new Vector2(2,-4);
            }
        }
        if (Animatronic == 1) //Scrap Baby
        {
            if (GlobalNightTime >= 20f && EventsTriggers[1] == false && AIPositions[1] == new Vector2(4,0))
            {
                EventsTriggers[1] = true;
                AIPositions[1] = new Vector2(2,-4);
            }
        }
        if (Animatronic == 3) //William Afton
        {
            if (GlobalNightTime >= 20f && EventsTriggers[3] == false && AIPositions[3] == new Vector2(4,0))
            {
                EventsTriggers[3] = true;
                AIPositions[3] = new Vector2(6,-4);
            }
        }
        if (Animatronic == 5) //Lefty //This is Intentional, you can remove :troll:
        {
            if (GlobalNightTime >= 20f && EventsTriggers[2] == false && AIPositions[2] == new Vector2(4,0))
            {
                EventsTriggers[2] = true;
                AIPositions[2] = new Vector2(6,-4);
            }
        }
    }

}