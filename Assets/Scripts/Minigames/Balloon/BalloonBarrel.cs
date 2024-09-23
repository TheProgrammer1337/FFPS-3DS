using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BalloonBarrel : MonoBehaviour
{
    public Sprite Frame1;
    public Sprite Frame2;
    public Sprite TwoBalloons;
    public Sprite HelpyBalloon;
    public GameObject barrel;
    bool animationbool = true;
    public AudioSource horn;
    public GameObject WinText;
    bool started = false;
    public GameObject pressa;
    bool done;
    public GameObject scoretext;
    public bool cart = false;
    // Use this for initialization
    void Start()
    {
        StartCoroutine("Animation");
        StartCoroutine("StartDelay");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            if (started == true)
            {
                animationbool = false;
            }
        }
        if (started == true && done == false)
        {
            pressa.SetActive(true);
            done = true;
        }


    }
    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(3.3f);
        started = true;
    }
    IEnumerator Animation()
    {
        while (animationbool)
        {
            if (animationbool)
            {
                yield return new WaitForSeconds(0.35f);
            }
            gameObject.GetComponent<Image>().sprite = Frame1;
            if (animationbool)
            {
                yield return new WaitForSeconds(0.35f);
            }
            gameObject.GetComponent<Image>().sprite = Frame2;
        }
        horn.Play();
        barrel.GetComponent<Image>().sprite = TwoBalloons;
        gameObject.GetComponent<Image>().sprite = HelpyBalloon;
        pressa.SetActive(false);
        WinText.SetActive(true);
        scoretext.SetActive(true);
        if (cart == true)
        {
            int rand = Random.Range(0, 6);
            switch (rand)
            {
                case 1:
                    PlayerPrefs.SetInt("FazRatingGain", 500);
                    break;
                case 2:
                    PlayerPrefs.SetInt("FazRatingGain", 1000);
                    break;
                case 3:
                    PlayerPrefs.SetInt("FazRatingGain", 2000);
                    break;
                case 4:
                    PlayerPrefs.SetInt("FazRatingGain", 3000);
                    break;
                case 5:
                    PlayerPrefs.SetInt("FazRatingGain", 4000);
                    break;

                case 6:
                    PlayerPrefs.SetInt("FazRatingGain", 5000);
                    break;

                default:
                    break;
            }
            scoretext.GetComponent<Text>().text = PlayerPrefs.GetInt("FazRatingGain").ToString();

        }
        else
        {
            PlayerPrefs.SetInt("FazRatingGain", 250);
        }
        PlayerPrefs.Save();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Tycoon");
    }
}
