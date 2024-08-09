using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ScrapBaby : MonoBehaviour
{
    Image image;


    public Sprite Frame1, Frame2, Frame3, Frame4, Frame5, Frame6, Frame7, Frame8, Frame9, Frame10, Frame11, Frame12, Frame13, Frame14;

    public Sprite Gaze1;
    public Sprite Gaze2;
    public Sprite Gaze3;
    public Sprite Gaze4;
    public Sprite Gaze5;
    public Sprite Gaze6;
    public Sprite Gaze7;


    public GameObject Light1;
    public GameObject Light2;

    public GameObject Black;

    public AudioSource TwoOne;

    public GameObject CassetteRecorder;

    public TapeRecorder TapeRecorder;

    public bool isup = true;

    bool done = false;
    bool moving = false;

    // Use this for initialization
    void Start()
    {
        image = gameObject.GetComponent<Image>();
        PlayerPrefs.SetInt("HasCompleted8BitIntro", 1);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (isup == true)
            {
                if (done == false)
                {
                    if (moving == false)
                    {
                        StartCoroutine("LookDown");
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isup == false)
            {
                if (moving == false)
                {
                    StartCoroutine("LookUp");
                }

            }
        }
        if (TapeRecorder.length < 0.3f)
        {
            if (done == false)
            {

                done = true;
                if (isup == false)
                {
                    StartCoroutine("LookUp");
                }
                StartCoroutine("ScaryJumpscare");

            }

        }

    }
    IEnumerator LookDown()
    {
        moving = true;
        yield return new WaitForSeconds(0.030f);
        gameObject.GetComponent<Image>().sprite = Frame1;
        yield return new WaitForSeconds(0.030f);
        gameObject.GetComponent<Image>().sprite = Frame2;
        yield return new WaitForSeconds(0.030f);
        gameObject.GetComponent<Image>().sprite = Frame3;
        yield return new WaitForSeconds(0.030f);
        gameObject.GetComponent<Image>().sprite = Frame4;
        yield return new WaitForSeconds(0.030f);
        gameObject.GetComponent<Image>().sprite = Frame5;
        yield return new WaitForSeconds(0.030f);
        gameObject.GetComponent<Image>().sprite = Frame6;
        Light1.SetActive(false);
        Light2.SetActive(false);
        yield return new WaitForSeconds(0.030f);
        gameObject.GetComponent<Image>().sprite = Frame7;
        yield return new WaitForSeconds(0.030f);
        gameObject.GetComponent<Image>().sprite = Frame8;
        yield return new WaitForSeconds(0.030f);
        gameObject.GetComponent<Image>().sprite = Frame9;
        yield return new WaitForSeconds(0.030f);
        gameObject.GetComponent<Image>().sprite = Frame10;
        yield return new WaitForSeconds(0.030f);
        gameObject.GetComponent<Image>().sprite = Frame11;
        yield return new WaitForSeconds(0.030f);
        gameObject.GetComponent<Image>().sprite = Frame12;
        yield return new WaitForSeconds(0.030f);
        gameObject.GetComponent<Image>().sprite = Frame13;
        yield return new WaitForSeconds(0.030f);
        gameObject.GetComponent<Image>().sprite = Frame14;
        CassetteRecorder.GetComponent<Image>().color = new Color(CassetteRecorder.GetComponent<Image>().color.r, CassetteRecorder.GetComponent<Image>().color.g, CassetteRecorder.GetComponent<Image>().color.b, 1);
        isup = false;
        moving = false;

    }
    IEnumerator LookUp()
    {
        moving = true;

        gameObject.GetComponent<Image>().sprite = Frame14;

        yield return new WaitForSeconds(0.030f);
        gameObject.GetComponent<Image>().sprite = Frame13;
        CassetteRecorder.GetComponent<Image>().color = new Color(CassetteRecorder.GetComponent<Image>().color.r, CassetteRecorder.GetComponent<Image>().color.g, CassetteRecorder.GetComponent<Image>().color.b, 0);
        yield return new WaitForSeconds(0.030f);
        gameObject.GetComponent<Image>().sprite = Frame12;
        yield return new WaitForSeconds(0.030f);
        gameObject.GetComponent<Image>().sprite = Frame11;
        yield return new WaitForSeconds(0.030f);
        gameObject.GetComponent<Image>().sprite = Frame10;
        yield return new WaitForSeconds(0.030f);
        gameObject.GetComponent<Image>().sprite = Frame9;
        yield return new WaitForSeconds(0.030f);
        gameObject.GetComponent<Image>().sprite = Frame8;
        yield return new WaitForSeconds(0.030f);
        gameObject.GetComponent<Image>().sprite = Frame7;
        yield return new WaitForSeconds(0.030f);
        gameObject.GetComponent<Image>().sprite = Frame6;
        Light1.SetActive(true);
        Light2.SetActive(true);
        yield return new WaitForSeconds(0.030f);
        gameObject.GetComponent<Image>().sprite = Frame5;
        yield return new WaitForSeconds(0.030f);
        gameObject.GetComponent<Image>().sprite = Frame4;
        yield return new WaitForSeconds(0.030f);
        gameObject.GetComponent<Image>().sprite = Frame3;
        yield return new WaitForSeconds(0.030f);
        gameObject.GetComponent<Image>().sprite = Frame2;
        yield return new WaitForSeconds(0.030f);
        gameObject.GetComponent<Image>().sprite = Frame1;
        yield return new WaitForSeconds(0.030f);
        isup = true;
        moving = false;
    }
    IEnumerator ScaryJumpscare()
    {
        yield return new WaitForSeconds(1.3f);
        TwoOne.Play();
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<Image>().sprite = Gaze1;
        yield return new WaitForSeconds(0.08f);
        gameObject.GetComponent<Image>().sprite = Gaze2;
        yield return new WaitForSeconds(0.08f);
        gameObject.GetComponent<Image>().sprite = Gaze3;
        yield return new WaitForSeconds(0.08f);
        gameObject.GetComponent<Image>().sprite = Gaze4;
        yield return new WaitForSeconds(0.08f);
        gameObject.GetComponent<Image>().sprite = Gaze5;
        yield return new WaitForSeconds(0.08f);
        gameObject.GetComponent<Image>().sprite = Gaze6;
        yield return new WaitForSeconds(0.08f);
        gameObject.GetComponent<Image>().sprite = Gaze7;
        yield return new WaitForSeconds(1f);
        Black.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneName: "Tycoon");
        SceneManager.UnloadSceneAsync(sceneName: "FirstInterrogation");

    }
}
