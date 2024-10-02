using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.N3DS;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BasketBall : MonoBehaviour
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
    public Sprite Helpy1, Helpy2, HelpyJump, HelpyDance1, HelpyDance2, HelpyDance3;
    public Animation animator;
    public AnimationClip clip;
    public AudioSource shoot2;
    public AudioSource hoop;
    public AudioSource winsound;
    public GameObject ScorePrefab;
    public Transform scoreSpawn;
    public Transform UpperCanvas;
    // Use this for initialization
    void Start()
    {
        leftSideX = box.anchoredPosition.x - (box.rect.width / 3.1f);
        rightSideX = box.anchoredPosition.x + (box.rect.width / 3.1f);
        UnityEngine.Application.targetFrameRate = 60;
        StartCoroutine("HelpyAnimation");
        Invoke("Starting", 3.5f);
    }
    public float pointA = -5f; 
    public float pointB = 5f; 
    public float speed = 2f;
    public int time = 30;
    public int score;
    public Text counterText;
    public Text scoreCounter;
    public Text timeText;
    public GameObject assets;
    public GameObject subassets;
    bool jackpot;
    bool started;
    bool done;
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
                if (pointerArrow.anchoredPosition.x > leftSideX + boxRadius && pointerArrow.anchoredPosition.x < rightSideX - boxRadius)
                {
                    UnityEngine.Debug.Log("success");
                    counter += 1;
                    score += 25;
                    win = true;
                    animator.Play("BallAnimation");
                    Invoke("Delayagain", clip.length);
                    leftSideX = box.anchoredPosition.x - (box.rect.width / 3.1f);
                    rightSideX = box.anchoredPosition.x + (box.rect.width / 3.1f);
                }
                else
                {
                    animator.Play("BallAnimation - Copy");
                    Invoke("Delayagain", clip.length);
                }
                pointerArrow.GetComponent<Image>().color = new Color(255, 255, 255, 0);
                Invoke("MoveDelay", 0.5f);
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
            counterText.text = counter.ToString();
            scoreCounter.text = score.ToString();
            hoop.Play();
            Instantiate(ScorePrefab, scoreSpawn.position, Quaternion.identity, UpperCanvas);
            box.sizeDelta -= new Vector2(4.5f, 0);
            win = false;
        }
        pointerArrow.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        moving = true;
        pointerArrow.anchoredPosition = new Vector2(33.7f, 21.3f);

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
                yield return new WaitForSeconds(0.4f);

                if (done == true)
                {
                    break;
                }

                image.sprite = Helpy2;
                if (thrown)
                {
                    break;
                }
                yield return new WaitForSeconds(0.4f);
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
    IEnumerator HelpyAnimation2()
    {
        Image image = GetComponent<Image>();
        RectTransform rectTransform = image.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(400, 400);
        transform.localPosition = new Vector2(0, -82.6f);
        animator.gameObject.SetActive(false);
        while (true)
        {
            image.sprite = HelpyDance1;

            yield return new WaitForSeconds(0.4f);

            image.sprite = HelpyDance2;

            yield return new WaitForSeconds(0.4f);
            image.sprite = HelpyDance3;

            yield return new WaitForSeconds(0.4f);
            image.sprite = HelpyDance2;

            yield return new WaitForSeconds(0.4f);
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
                triggered = true;
                subassets.SetActive(false);
                moving = false;
                done = true;
                StartCoroutine(HelpyAnimation2());
                scoreCounter.gameObject.AddComponent<BlinkingText>();
                scoreCounter.gameObject.GetComponent<BlinkingText>().speed = 0.15f;
                winsound.Play();
                Invoke("Finish", 4f);
                PlayerPrefs.SetInt("FazRatingGain", score);
                PlayerPrefs.Save();
            }
        }
    }
    void Finish()
    {
        SceneManager.LoadScene("Tycoon");
    }
    void Delayagain()
    {
        animator.Stop();
        animator.gameObject.transform.localPosition = new Vector3(-28.6f, -78);
    }
}
