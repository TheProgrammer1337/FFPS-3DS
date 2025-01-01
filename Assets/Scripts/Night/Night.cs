using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Night : MonoBehaviour
{
    public Sprite defaultframe;
    public Sprite[] turnleftframe;
    public Sprite[] turnrightframe;

    // fix this //Dimolade: i dont know what this does just tell me in the dc and i might
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

    public FFPSAI AIManager; //AI Logic

    public Sprite[] CircleFrame;

    public Sprite image;
    public Sprite image2;
    public Sprite ogimage;
    public Sprite ogimage2;

    public Sprite[] fanframe;

    // fix this
    public AudioSource Boop;
    GameObject buttontask;
    bool taskstarted;
    public float tasktimeleft;
    int tasksdone;
    int position = 1;
    int tasklocation;
    public int selectedmenu;
    bool intaskselection;
    bool insilentvent = true;
    public string activeuse;

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
                StartCoroutine("TurnLeft", 1);
                position = 0;
                turning = true;
                screen.SetActive(false);
                BottomScreen.SetActive(false);
            }
            if (position == 2 && turning == false)
            {
                StartCoroutine("TurnRight", -1);
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
            if (selectedmenu < 3)
            {
                selectedmenu += 1;
            }
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
                    child2.GetComponent<Image>().sprite = fanframe[0];
                }


            }


        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (intaskselection == false)
            {
                if (selectedmenu > 0)
                {
                    selectedmenu -= 1;
                }
                if (selectedmenu == 0)
                {
                    MotionDetector.SetActive(false);
                    TasksMain.SetActive(true);
                    Tasks.SetActive(true);
                    LoopingTaskCircle.SetActive(false);
                    TasksAdvertising.SetActive(false);
                    TasksOrdering.SetActive(false);
                    TasksMaintenance.SetActive(false);

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
                StartCoroutine("TurnRight", 1);
                position = 2;
                turning = true;
                screen.SetActive(false);
                BottomScreen.SetActive(false);
            }
            if (position == 0 && turning == false)
            {
                StartCoroutine("TurnLeft", -1);
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
    IEnumerator TurnRight(int direction2)
    {

        int currentFrameIndex = 0;
        if (direction2 == -1)
        {
            currentFrameIndex = turnrightframe.Length - 1;
        }
        Image imgcomp = GetComponent<Image>();
        for (int i = 0; i < turnrightframe.Length; i++)
        {
            yield return new WaitForSeconds(0.025f);
            imgcomp.sprite = turnrightframe[currentFrameIndex];

            currentFrameIndex += direction2;

            //// reverse after end
            //if (currentFrameIndex >= turnleftframe.Length - 1 || currentFrameIndex < 0)
            //{
            //    direction *= -1;
            //    currentFrameIndex += direction;
            //}
        }
        turning = false;
        if (direction2 == -1)
        {
            imgcomp.sprite = defaultframe;
            screen.SetActive(true);
            BottomScreen.SetActive(true);
        }

    }

    IEnumerator TurnLeft(int direction2)
    {

        int currentFrameIndex = 0;
        if (direction2 == -1)
        {
            currentFrameIndex = turnleftframe.Length - 1;
        }
        Image imgcomp = GetComponent<Image>();
        for (int i = 0; i < turnleftframe.Length; i++)
        {
            yield return new WaitForSeconds(0.025f);
            imgcomp.sprite = turnleftframe[currentFrameIndex];

            currentFrameIndex += direction2;

        }
        if (direction2 == -1)
        {
            imgcomp.sprite = defaultframe;
            screen.SetActive(true);
            BottomScreen.SetActive(true);
        }
        turning = false;

    }
    IEnumerator CircleAnimation()
    {
        int currentFrameIndex = 0;
        Image imgcomp = LoopingTaskCircle.GetComponent<Image>();
        while (true)
        {
            Debug.Log("test");
            yield return new WaitForSeconds(0.05f);
            imgcomp.sprite = CircleFrame[currentFrameIndex];

            currentFrameIndex += 1;

            if (currentFrameIndex >=  CircleFrame.Length)
            {
                currentFrameIndex = 0;
            }

        }

    }
    IEnumerator FanAnimation()
    {
        int currentFrameIndex = 0;
        Image imgcomp = movingfan.GetComponent<Image>();
        while (activeuse == "silentvent")
        {

            yield return new WaitForSeconds(0.25f);
            Debug.Log("test");
            imgcomp.sprite = fanframe[currentFrameIndex];

            currentFrameIndex += 1;

            // reverse after end
            if (currentFrameIndex >= fanframe.Length)
            {
                currentFrameIndex = 0;
            }
        }

    }
}
