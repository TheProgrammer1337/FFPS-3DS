using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Night : MonoBehaviour
{
    //HORRIFIC CODE AHEAD
    public Sprite defaultframe;
    public Sprite turnleftframe1;
    public Sprite turnleftframe2;
    public Sprite turnleftframe3;
    public Sprite turnleftframe4;
    public Sprite turnleftframe5;
    public Sprite turnleftframe6;
    public Sprite turnleftframe7;
    public Sprite turnleftframe8;
    public Sprite turnleftframe9;
    public Sprite turnleftframe10;
    public Sprite turnleftframe11;
    public Sprite turnleftframe12;
    public Sprite turnleftframe13;
    public Sprite turnleftframe14;
    public Sprite turnleftframe15;
    public Sprite turnleftframe16;

    public Sprite turnrightframe1;
    public Sprite turnrightframe2;
    public Sprite turnrightframe3;
    public Sprite turnrightframe4;
    public Sprite turnrightframe5;
    public Sprite turnrightframe6;
    public Sprite turnrightframe7;
    public Sprite turnrightframe8;
    public Sprite turnrightframe9;
    public Sprite turnrightframe10;
    public Sprite turnrightframe11;
    public Sprite turnrightframe12;
    public Sprite turnrightframe13;
    public Sprite turnrightframe14;
    public Sprite turnrightframe15;
    public Sprite turnrightframe16;

    public GameObject TasksMain;
    public GameObject Tasks;
    public GameObject TasksMaintenance;
    public GameObject TasksAdvertising;
    public GameObject TasksOrdering;
    public GameObject screen;
    public GameObject LoopingTaskCircle;
    public GameObject BottomScreen;
    public GameObject movingfan;
    public GameObject MotionDetector;
    public GameObject SilentVentilation;

    public Sprite CircleFrame1;
    public Sprite CircleFrame2;
    public Sprite CircleFrame3;
    public Sprite CircleFrame4;
    public Sprite CircleFrame5;
    public Sprite CircleFrame6;
    public Sprite CircleFrame7;
    public Sprite CircleFrame8;
    public Sprite CircleFrame9;
    public Sprite CircleFrame10;
    public Sprite image;
    public Sprite image2;
    public Sprite ogimage;
    public Sprite ogimage2;

    public Sprite fanframe1;
    public Sprite fanframe2;
    public Sprite fanframe3;
    public Sprite fanframe4;


    public AudioSource Boop;
    GameObject buttontask;
    bool taskstarted;
    public float tasktimeleft;
    int tasksdone;
    int position = 1;
    int tasklocation;
    int selectedmenu;
    bool intaskselection;
    bool insilentvent = true;
    public string activeuse;

    // Use this for initialization
    void Start()
    {

    }
    public void ButtonClicked(GameObject button)
    {
        if (button.name == "Maintenance")
        {
            intaskselection = true;
            TasksMain.SetActive(false);
            TasksMaintenance.SetActive(true);
            LoopingTaskCircle.SetActive(false);
            if (taskstarted == true && tasklocation == 1)
            {
                LoopingTaskCircle.SetActive(true);
            }
        }
        else if (button.name == "Advertising")
        {
            intaskselection = true;
            TasksMain.SetActive(false);
            TasksAdvertising.SetActive(true);
            LoopingTaskCircle.SetActive(false);
            if (taskstarted == true && tasklocation == 2)
            {
                LoopingTaskCircle.SetActive(true);
            }
        }
        else if (button.name == "Ordering")
        {
            intaskselection = true;
            TasksMain.SetActive(false);
            TasksOrdering.SetActive(true);
            LoopingTaskCircle.SetActive(false);
            if (taskstarted == true && tasklocation == 3)
            {
                LoopingTaskCircle.SetActive(true);
            }
        }

        else if (button.name.Contains("MaintenanceTasks") == true)
        {
            if (taskstarted == true)
            {
                buttontask.GetComponent<TimeLeftStore>().timeleft = tasktimeleft;
            }
            taskstarted = true;
            tasktimeleft = button.GetComponent<TimeLeftStore>().timeleft;
            tasklocation = 1;
            LoopingTaskCircle.SetActive(true);
            LoopingTaskCircle.transform.localPosition = new Vector3(4.7f, button.transform.localPosition.y);
            StopCoroutine("CircleAnimation");
            StartCoroutine("CircleAnimation");
            buttontask = button;
            activeuse = "task";
        }

        else if (button.name.Contains("AdvertisingTasks") == true)
        {
            if (taskstarted == true)
            {
                buttontask.GetComponent<TimeLeftStore>().timeleft = tasktimeleft;
            }
            taskstarted = true;
            tasktimeleft = button.GetComponent<TimeLeftStore>().timeleft;
            tasklocation = 2;
            LoopingTaskCircle.SetActive(true);
            LoopingTaskCircle.transform.localPosition = new Vector3(4.7f, button.transform.localPosition.y);
            StopCoroutine("CircleAnimation");
            StartCoroutine("CircleAnimation");
            buttontask = button;
            activeuse = "task";
        }
        else if (button.name.Contains("OrderingTasks") == true)
        {
            if (taskstarted == true)
            {
                buttontask.GetComponent<TimeLeftStore>().timeleft = tasktimeleft;
            }
            taskstarted = true;
            tasktimeleft = button.GetComponent<TimeLeftStore>().timeleft;
            tasklocation = 3;
            LoopingTaskCircle.SetActive(true);
            LoopingTaskCircle.transform.localPosition = new Vector3(4.7f, button.transform.localPosition.y);
            StopCoroutine("CircleAnimation");
            StartCoroutine("CircleAnimation");
            buttontask = button;
            activeuse = "task";
        }
        else if (button.name == "Back")
        {
            intaskselection = false;
            if (taskstarted == true)
            {
                buttontask.GetComponent<TimeLeftStore>().timeleft = tasktimeleft;
                taskstarted = false;
                tasklocation = 0;
            }
            TasksMain.SetActive(true);
            TasksMaintenance.SetActive(false);
            TasksAdvertising.SetActive(false);
            TasksOrdering.SetActive(false);
            LoopingTaskCircle.SetActive(false);
            activeuse = "none";

        }
        else if (button.name == "SilentVent")
        {
            button.transform.parent.gameObject.GetComponent<BlinkingImage>().enabled = true;
            button.transform.parent.gameObject.GetComponent<Image>().sprite = image;
            button.transform.parent.gameObject.transform.localScale = new Vector3(45, 45);
            button.transform.parent.gameObject.transform.position -= new Vector3(35, 0);
            activeuse = "silentvent";
            StartCoroutine("FanAnimation");
            button.SetActive(false);
        }
        else if (button.name == "MotionD")
        {
            button.transform.parent.gameObject.GetComponent<Image>().sprite = image2;
            button.transform.parent.gameObject.GetComponent<BlinkingImage>().enabled = true;
            button.transform.parent.gameObject.transform.localScale = new Vector3(18, 21);
            button.transform.parent.gameObject.transform.position -= new Vector3(90, 0);
            activeuse = "motiond";
            button.SetActive(false);
        }
    }
    bool turning;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (position == 1 && turning == false)
            {
                StartCoroutine("TurnLeft");
                position = 0;
                turning = true;
                screen.SetActive(false);
                BottomScreen.SetActive(false);
            }
            if (position == 2 && turning == false)
            {
                StartCoroutine("TurnLeftBack");
                position = 1;
                turning = true;

            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (intaskselection == true)
            {
                intaskselection = false;
                if (taskstarted == true)
                {
                    buttontask.GetComponent<TimeLeftStore>().timeleft = tasktimeleft;
                    taskstarted = false;
                    tasklocation = 0;
                }
            }
            selectedmenu += 1;
            if (selectedmenu == 1)
            {
                MotionDetector.SetActive(true);
                Tasks.SetActive(false);
                if (activeuse != "motiond")
                {
                    foreach (Transform child in MotionDetector.gameObject.transform)
                    {

                        if (child.name == "1673")
                        {
                            child.GetComponent<Image>().sprite = ogimage2;
                            child.transform.localScale = new Vector3(50, 50);
                            child.transform.localPosition = new Vector3(-17.2f, -102.4f);
                            child.GetComponent<BlinkingImage>().enabled = false;
                            child.gameObject.SetActive(false);
                            child.gameObject.SetActive(true);
                            child.transform.GetChild(0).gameObject.SetActive(true);
                        }

                        child.GetComponent<Image>().color = new Color(child.GetComponent<Image>().color.r, child.GetComponent<Image>().color.g, child.GetComponent<Image>().color.b, 1);
                    }
                }

            }
            if (selectedmenu == 3)
            {
                SilentVentilation.SetActive(true);
                MotionDetector.SetActive(false);
                if (activeuse != "silentvent")
                {
                    Transform child = SilentVentilation.gameObject.transform.GetChild(2);
                    Transform child2 = SilentVentilation.gameObject.transform.GetChild(1);

                    child.GetComponent<Image>().sprite = ogimage;
                    child.transform.localScale = new Vector3(60, 90);
                    child.transform.localPosition = new Vector3(-6.9f, -100.5f);
                    child.GetComponent<BlinkingImage>().enabled = false;
                    child.gameObject.SetActive(false);
                    child.gameObject.SetActive(true);
                    child.transform.GetChild(0).gameObject.SetActive(true);
                    child.GetComponent<Image>().color = new Color(child.GetComponent<Image>().color.r, child.GetComponent<Image>().color.g, child.GetComponent<Image>().color.b, 1);
                    child2.GetComponent<Image>().sprite = fanframe1;
                }


            }


        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (intaskselection == false)
            {
                selectedmenu -= 1;
                if (selectedmenu == 0)
                {
                    MotionDetector.SetActive(false);
                    TasksMain.SetActive(true);
                    Tasks.SetActive(true);
                }
                else if (selectedmenu == 1)
                {
                    MotionDetector.SetActive(true);
                    SilentVentilation.SetActive(false);
                    if (activeuse != "motiond")
                    {
                        foreach (Transform child in MotionDetector.gameObject.transform)
                        {

                            if (child.name == "1673")
                            {
                                child.GetComponent<Image>().sprite = ogimage2;
                                child.transform.localScale = new Vector3(50, 50);
                                child.transform.localPosition = new Vector3(-17.2f, -102.4f);
                                child.GetComponent<BlinkingImage>().enabled = false;
                                child.gameObject.SetActive(false);
                                child.gameObject.SetActive(true);
                                child.transform.GetChild(0).gameObject.SetActive(true);
                            }

                            child.GetComponent<Image>().color = new Color(child.GetComponent<Image>().color.r, child.GetComponent<Image>().color.g, child.GetComponent<Image>().color.b, 1);
                        }
                    }
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (position == 1 && turning == false)
            {
                StartCoroutine("TurnRight");
                position = 2;
                turning = true;
                screen.SetActive(false);
                BottomScreen.SetActive(false);
            }
            if (position == 0 && turning == false)
            {
                StartCoroutine("TurnRightBack");
                position = 1;
                turning = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Boop.Play();
        }
        if (taskstarted == true)
        {
            tasktimeleft -= Time.deltaTime;
        }
        if (tasktimeleft < 0)
        {
            taskstarted = false;
            tasksdone += 1;
            Destroy(buttontask);
            LoopingTaskCircle.SetActive(false);
        }

    }
    IEnumerator TurnLeft()
    {
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe1;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe2;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe3;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe4;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe5;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe6;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe7;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe8;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe9;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe10;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe11;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe12;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe13;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe14;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe15;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe16;
        turning = false;
    }
    IEnumerator TurnLeftBack()
    {
        gameObject.GetComponent<Image>().sprite = turnrightframe16;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe15;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe14;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe13;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe12;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe11;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe10;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe9;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe8;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe7;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe6;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe5;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe4;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe3;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe2;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe1;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = defaultframe;
        screen.SetActive(true);
        BottomScreen.SetActive(true);
        turning = false;
    }
    IEnumerator TurnRight()
    {
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe1;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe2;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe3;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe4;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe5;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe6;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe7;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe8;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe9;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe10;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe11;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe12;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe13;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe14;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe15;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnrightframe16;
        turning = false;
    }
    IEnumerator TurnRightBack()
    {
        gameObject.GetComponent<Image>().sprite = turnleftframe16;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe15;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe14;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe13;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe12;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe11;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe10;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe9;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe8;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe7;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe6;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe5;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe4;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe3;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe2;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = turnleftframe1;
        yield return new WaitForSeconds(0.019f);
        gameObject.GetComponent<Image>().sprite = defaultframe;
        screen.SetActive(true);
        BottomScreen.SetActive(true);
        turning = false;
    }
    IEnumerator CircleAnimation()
    {
        while (intaskselection == true)
        {
            yield return new WaitForSeconds(0.035f);
            LoopingTaskCircle.GetComponent<Image>().sprite = CircleFrame1;
            yield return new WaitForSeconds(0.035f);
            LoopingTaskCircle.GetComponent<Image>().sprite = CircleFrame2;
            yield return new WaitForSeconds(0.035f);
            LoopingTaskCircle.GetComponent<Image>().sprite = CircleFrame3;
            yield return new WaitForSeconds(0.035f);
            LoopingTaskCircle.GetComponent<Image>().sprite = CircleFrame4;
            yield return new WaitForSeconds(0.035f);
            LoopingTaskCircle.GetComponent<Image>().sprite = CircleFrame5;
            yield return new WaitForSeconds(0.035f);
            LoopingTaskCircle.GetComponent<Image>().sprite = CircleFrame6;
            yield return new WaitForSeconds(0.035f);
            LoopingTaskCircle.GetComponent<Image>().sprite = CircleFrame7;
            yield return new WaitForSeconds(0.035f);
            LoopingTaskCircle.GetComponent<Image>().sprite = CircleFrame8;
            yield return new WaitForSeconds(0.035f);
            LoopingTaskCircle.GetComponent<Image>().sprite = CircleFrame9;
            yield return new WaitForSeconds(0.035f);
            LoopingTaskCircle.GetComponent<Image>().sprite = CircleFrame10;
        }

    }
    IEnumerator FanAnimation()
    {
        while (activeuse == "silentvent")
        {

            movingfan.GetComponent<Image>().sprite = fanframe1;
            yield return new WaitForSeconds(0.25f);
            movingfan.GetComponent<Image>().sprite = fanframe2;
            yield return new WaitForSeconds(0.25f);
            movingfan.GetComponent<Image>().sprite = fanframe3;
            yield return new WaitForSeconds(0.25f);
            movingfan.GetComponent<Image>().sprite = fanframe4;
            yield return new WaitForSeconds(0.25f);
        }

    }
}
//END OF HORRIFIC CODE
