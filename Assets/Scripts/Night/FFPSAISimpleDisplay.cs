using UnityEngine;

public class FFPSAISimpleDisplay : MonoBehaviour
{
    public FFPSAI MainAI;
    public GameObject Display;
    public Transform[] AnimatronicRepresentations;
    public Vector3 TopLeftCorner;
    public float HorizontalStep;
    public float VerticalStep;

    void Start()
    {
        FFPSAI.OnAnimatronicUpdate += UpdateAnimatronicPosition;

        // Sync animatronic positions at the start
        for (int i = 0; i < MainAI.AIPositions.Length; i++)
        {
            UpdateAnimatronicPosition(i);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightAlt))
        {
            Display.SetActive(!Display.activeSelf);
        }
    }

    void UpdateAnimatronicPosition(int animatronic)
    {
        if (animatronic < 0 || animatronic >= MainAI.AIPositions.Length) return;
        Vector2 animatronicPosition = MainAI.AIPositions[animatronic];
        if (animatronic < 0 || animatronic >= AnimatronicRepresentations.Length) return;
        AnimatronicRepresentations[animatronic].localPosition = TopLeftCorner + new Vector3(animatronicPosition.x * HorizontalStep, -animatronicPosition.y * VerticalStep, 0);
    }
}