using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.N3DS;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LadderTower : MonoBehaviour
{
    public RectTransform pointerArrow;
    public bool moving;
    public float boxRadius;
    public RectTransform box;
    public float leftSideX;
    public float rightSideX;
    public int counter;
    
    bool win;
    bool thrown;
    public Sprite Helpy1, Helpy2, Helpy3, HelpyJump, HelpyFall;
    public AudioSource music;
    public AudioSource shoot2;
    public AudioSource snap;
    public AudioSource airhorn;
    public Transform UpperCanvas;
    public GameObject winText;
    // Use this for initialization
    void Start()
    {

        UnityEngine.Application.targetFrameRate = 60;
        StartCoroutine("HelpyAnimation");
        Invoke("Starting", 4.05f);
        leftBoundary = box.anchoredPosition.x - (box.rect.width / 3);
        rightBoundary = box.anchoredPosition.x + (box.rect.width / 3);
    }
    public float pointA = -5f; 
    public float pointB = 5f; 
    public float speed = 2f;
    public int time = 30;
    public int score;
    public Text scoreText;
    public Text timeText;
    public GameObject assets;
    public GameObject subassets;
    bool jackpot;
    bool started;
    bool done;
    float leftBoundary;
    float rightBoundary;
    private bool movingToB = true;
    void Starting()
    {
        assets.SetActive(true);
        moving = true;
        StartCoroutine("Timer");

    }
    void Update()
    {
        if (moving)
        {
            float step = speed * Time.deltaTime;

            if (movingToB)
            {
                pointerArrow.anchoredPosition += new Vector2(step, 0);
                if (pointerArrow.anchoredPosition.x >= pointB)
                {
                    movingToB = false;
                }
            }
            else
            {
                pointerArrow.anchoredPosition -= new Vector2(step, 0);
                if (pointerArrow.anchoredPosition.x <= pointA)
                {
                    movingToB = true;

                }
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                moving = false;
                shoot2.Play();
                thrown = true;
                // there's probably a way better way to do this ngl
                if (pointerArrow.anchoredPosition.x > leftBoundary && pointerArrow.anchoredPosition.x < rightBoundary)
                {
                    UnityEngine.Debug.Log("success");
                    counter += 1;
                    win = true;
                    if (counter == 9)
                    {
                        StartCoroutine("Win");
                        StopCoroutine("Timer");
                    }
                    leftSideX = box.anchoredPosition.x - (box.rect.width / 3.1f);
                    rightSideX = box.anchoredPosition.x + (box.rect.width / 3.1f);
                    //gameObject.transform.localPosition -= new Vector3(40, 0);
                    StartCoroutine("HopAnimation");
                }
                else
                {

                    assets.SetActive(false);
                    StopAllCoroutines();
                    GetComponent<Image>().sprite = HelpyFall;
                    GetComponent<RectTransform>().sizeDelta = new Vector2(281, 231);
                    gameObject.transform.localScale = new Vector3(0.25f, 0.25f);
                    StartCoroutine("JumpingAnimation");
                }
                pointerArrow.GetComponent<Image>().color = new Color(255, 255, 255, 0);
                Invoke("MoveDelay", 0.1f);
                if (win == true)
                {
                    win = false;
                    box.sizeDelta -= new Vector2(10f, 0);
                    leftBoundary = box.anchoredPosition.x - (box.rect.width / 3f);
                    rightBoundary = box.anchoredPosition.x + (box.rect.width / 3f);
                }
            }
        }

    }
    void MoveDelay()
    {
        if (win == true)
        {
            if (jackpot == false && counter >= 20)
            {
                score += 5000;
                jackpot = true;
            }

            win = false;
        }
        pointerArrow.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        moving = true;
        pointerArrow.anchoredPosition = new Vector2(-52.59998f, 4.600002f);

    }
    IEnumerator JumpingAnimation()
    {
        Invoke("Snap", 0.6f);
        music.Stop();
        while (true)
        {
            yield return new WaitForEndOfFrame();
            gameObject.transform.localPosition -= new Vector3(0, 4, 0);
        }
    }
    IEnumerator Win()
    {
        yield return new WaitForSeconds(0.020f);
        score = 1000 + (time * 100);
        scoreText.gameObject.SetActive(true);
        scoreText.text = score.ToString();
        scoreText.gameObject.AddComponent<BlinkingText>();
        winText.SetActive(true);
        subassets.SetActive(false);
        music.Stop();
        airhorn.Play();
        PlayerPrefs.SetInt("FazRatingGain", score);
        PlayerPrefs.Save();
        Invoke("Finish", 3);
    }
    IEnumerator HopAnimation()
    {
        for (int i = 0; i < 8; i++)
        {
            yield return new WaitForSeconds(0.020f);
            gameObject.transform.localPosition -= new Vector3(5f, -1, 0);
        }
        for (int i = 0; i < 8; i++)
        {
            yield return new WaitForSeconds(0.020f);
            gameObject.transform.localPosition -= new Vector3(0, 1, 0);
        }

    }
    IEnumerator HelpyAnimation()
    {
        Image image = GetComponent<Image>();

        while (done == false)
        {
            while (!thrown)
            {
                image.sprite = Helpy1;
                if (thrown)
                {
                    break;
                }
                yield return new WaitForSeconds(0.2f);

                if (done == true)
                {
                    break;
                }

                image.sprite = Helpy2;
                if (thrown)
                {
                    break;
                }
                yield return new WaitForSeconds(0.2f);
                if (done == true)
                {
                    break;
                }
                image.sprite = Helpy3;
                if (thrown)
                {
                    break;
                }
                yield return new WaitForSeconds(0.2f);
                if (done == true)
                {
                    break;
                }
                image.sprite = Helpy2;
                if (thrown)
                {
                    break;
                }
                yield return new WaitForSeconds(0.2f);

                if (done == true)
                {
                    break;
                }

                image.sprite = Helpy1;
                if (thrown)
                {
                    break;
                }
                if (done == true)
                {
                    break;
                }
            }
            if (done == true)
            {
                break;
            }
            image.sprite = HelpyJump;

            yield return new WaitForSeconds(0.3f);
            thrown = false;
        }
    }

    IEnumerator Timer()
    {
        bool triggered = false;
        while (true)
        {

            yield return new WaitForSeconds(0.54f);
            time -= 1;
            timeText.text = time.ToString();
            if (time <= 0 && triggered == false)
            {
                StopAllCoroutines();
                StartCoroutine("JumpingAnimation");
                music.Stop();
                triggered = true;
                subassets.SetActive(false);
                moving = false;
                done = true;
                Invoke("Finish", 4f);
            }
        }
    }
    void Snap()
    {
        snap.Play();
        StartCoroutine(camerashake());
    }
    IEnumerator camerashake()
    {
        UpperCanvas.transform.localPosition += new Vector3(0f, 50, 0);
        yield return new WaitForSeconds(0.1f);
        UpperCanvas.transform.localPosition += new Vector3(0f, -50, 0);
    }
    void Finish()
    {
        SceneManager.LoadScene("Tycoon");
    }

}
