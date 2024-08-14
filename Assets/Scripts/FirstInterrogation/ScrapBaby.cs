using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ScrapBaby : MonoBehaviour
{
    Image image;


    public Sprite[] LookDownAnim;
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

        Light1.SetActive(false);
        for (int i = 0; i < LookDownAnim.Length; i++)
        {
            gameObject.GetComponent<Image>().sprite = LookDownAnim[i];
            yield return new WaitForSeconds(0.030f);
        }

        CassetteRecorder.GetComponent<Image>().color = new Color(CassetteRecorder.GetComponent<Image>().color.r, CassetteRecorder.GetComponent<Image>().color.g, CassetteRecorder.GetComponent<Image>().color.b, 1);
        isup = false;
        moving = false;
    }
    IEnumerator LookUp()
    {
        moving = true;

        Light2.SetActive(true);

        gameObject.GetComponent<Image>().sprite = LookDownAnim[13];

        CassetteRecorder.GetComponent<Image>().color = new Color(CassetteRecorder.GetComponent<Image>().color.r, CassetteRecorder.GetComponent<Image>().color.g, CassetteRecorder.GetComponent<Image>().color.b, 0);

        for (int i = LookDownAnim.Length - 1; i >= 0; i--)
        {
            gameObject.GetComponent<Image>().sprite = LookDownAnim[i];
            yield return new WaitForSeconds(0.030f);
        }
        Light1.SetActive(true);

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
