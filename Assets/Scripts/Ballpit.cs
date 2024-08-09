using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ballpit : MonoBehaviour
{
    public Sprite frame1;
    public Sprite frame2;
    public Sprite frame3;
    public Sprite Jumping;
    public GameObject Arrow;
    public Sprite Fallingframe1;
    public Sprite Fallingframe2;
    public Sprite Fallingframe3;
    public Sprite Fallingframe4;
    public int round = 1;
    public Sprite round1;
    public Sprite round2;
    public Sprite round3;
    public Sprite round4;
    public Sprite round5;

    public AudioSource music;
    public AudioSource Crack;
    public AudioSource Thud;
    public AudioSource Ballpitsounds;
    public AudioSource Jump;
    public AudioSource end;


    int fazrating = 0;
    public Text fazratingcounter;
    bool canjump = false;
    public GameObject RoundText;
    Image color;
    int speed = -6;
    public GameObject Balls;
    bool triggered = false;
    // Use this for initialization
    void Start()
    {
        color = GetComponent<Image>();
        gameObject.GetComponent<Image>().color = new Color(color.color.r, color.color.g, color.color.b, 0);
        Arrow.GetComponent<Image>().color = new Color(color.color.r, color.color.g, color.color.b, 0);

        StartCoroutine("HelpyAnimation");
        StartCoroutine("Round");

    }

    IEnumerator Round()
    {

        switch (round)
        {
            case 1:
                RoundText.GetComponent<Image>().sprite = round1;
                break;
            case 2:
                RoundText.GetComponent<Image>().sprite = round2;
                break;
            case 3:
                RoundText.GetComponent<Image>().sprite = round3;
                break;
            case 4:
                RoundText.GetComponent<Image>().sprite = round4;
                break;
            case 5:
                RoundText.GetComponent<Image>().sprite = round5;
                break;
        }
        if (music.isPlaying == false)
        {
            music.Play();
        }
        RoundText.GetComponent<Image>().color = new Color(color.color.r, color.color.g, color.color.b, 1);
        yield return new WaitForSeconds(2f);
        canjump = true;
        triggered = false;
        StartCoroutine("HelpyAnimation");
        playinganimation = false;
        Arrow.GetComponent<BallpitArrow>().going = true;
        gameObject.transform.localScale = new Vector3(21, 21, 0);
        gameObject.transform.localPosition = new Vector3(128.2f, 62.7f, 0);
        gameObject.GetComponent<Image>().color = new Color(color.color.r, color.color.g, color.color.b, 1);
        Arrow.GetComponent<Image>().color = new Color(color.color.r, color.color.g, color.color.b, 1);
        RoundText.GetComponent<Image>().color = new Color(color.color.r, color.color.g, color.color.b, 0);
    }
    bool playinganimation = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (canjump == true)
            {
                canjump = false;
                Arrow.GetComponent<BallpitArrow>().going = false;
                Jump.Play();
                gameObject.GetComponent<Image>().sprite = Jumping;
                StopAllCoroutines();
                StartCoroutine("JumpingAnimation");
                StartCoroutine("Delay");
                gameObject.transform.localScale = new Vector3(10, 17, 0);
            }

        }
        if (transform.localPosition.y < -65 && playinganimation == false)
        {
            playinganimation = true;
            StartCoroutine("FallingAnimation");
        }
    }
    IEnumerator HelpyAnimation()
    {
        gameObject.GetComponent<Image>().sprite = frame2;
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            gameObject.GetComponent<Image>().sprite = frame1;
            yield return new WaitForSeconds(0.5f);
            gameObject.GetComponent<Image>().sprite = frame2;
        }

    }
    IEnumerator JumpingAnimation()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.025f);
            gameObject.transform.localPosition += new Vector3(0, 10, 0);
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.7f);
        gameObject.transform.localScale = new Vector3(13, 13, 0);
        gameObject.GetComponent<Image>().sprite = frame3;
        gameObject.transform.localPosition = new Vector3(Arrow.transform.localPosition.x, 200);
        StopCoroutine("JumpingAnimation");
        yield return new WaitForSeconds(1f);
        while (gameObject.transform.localPosition.y > -80)
        {

            yield return new WaitForSeconds(0.015f);
            gameObject.transform.localPosition += new Vector3(0, speed, 0);


        }
    }
    public void OnTriggerEnter2D(Collider2D colliderthing)
    {
        Ballpitsounds.Play();
        Balls.SetActive(true);
        playinganimation = true;
        StopCoroutine("Delay");
        StopCoroutine("JumpingAnimation");
        Arrow.GetComponent<Image>().color = new Color(color.color.r, color.color.g, color.color.b, 0);
        gameObject.GetComponent<Image>().color = new Color(color.color.r, color.color.g, color.color.b, 0);
        round += 1;
        fazrating += 200;
        fazratingcounter.text = fazrating.ToString();
        if (round != 6)
        {
            StartCoroutine("Round");
        }
        else
        {
            end.Play();
            PlayerPrefs.SetInt("FazRatingGain", fazrating);
            PlayerPrefs.Save();
            StartCoroutine("WinDelay");
        }

    }
    IEnumerator FallingAnimation()
    {
        Debug.Log("triggered");
        gameObject.transform.localScale = new Vector3(23, 23, 0);
        gameObject.GetComponent<Image>().sprite = Fallingframe1;
        yield return new WaitForSeconds(0.09f);
        gameObject.GetComponent<Image>().sprite = Fallingframe2;
        music.Stop();
        Thud.Play();
        Crack.Play();
        yield return new WaitForSeconds(0.09f);
        gameObject.GetComponent<Image>().sprite = Fallingframe3;
        yield return new WaitForSeconds(0.09f);
        Arrow.GetComponent<Image>().color = new Color(color.color.r, color.color.g, color.color.b, 0);
        gameObject.GetComponent<Image>().sprite = Fallingframe4;
        yield return new WaitForSeconds(0.09f);
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<Image>().color = new Color(color.color.r, color.color.g, color.color.b, 0);
        round += 1;
        if (round != 6)
        {
            StartCoroutine("Round");
        }
        else
        {
            end.Play();
            yield return new WaitForSeconds(1f);
            StartCoroutine("WinDelay");

        }


    }
    IEnumerator WinDelay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneName: "Tycoon");
        SceneManager.UnloadSceneAsync(sceneName: "BallPit");
    }
}
