using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MinigameKid : MonoBehaviour
{

    public Sprite image;
    public Sprite image2;

    public Sprite Eating1;
    public Sprite Eating2;

    public GameObject Score;
    public GameObject RoundOne;
    public AudioSource eatsoundeffect;
    public AudioSource ScoreSound;


    public ScoreHolder Counter;

    int PizzaEaten = 0;

    void Start()
    {
        image = GetComponent<Image>().sprite;
        StartBlinking();
    }

    IEnumerator Blink()
    {
        while (true)
        {

            //image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
            gameObject.GetComponent<Image>().sprite = image2;
            //Play sound
            yield return new WaitForSeconds(0.40f);
            if (gameObject.GetComponent<Image>().sprite == image2)
            {
                //image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
                gameObject.GetComponent<Image>().sprite = image;
                //Play sound
                yield return new WaitForSeconds(0.40f);
            }



        }
    }
    IEnumerator Eat()
    {
        gameObject.GetComponent<Image>().sprite = Eating1;
        yield return new WaitForSeconds(0.10f);
        gameObject.GetComponent<Image>().sprite = Eating2;
        yield return new WaitForSeconds(0.10f);
        StartCoroutine("Blink");

    }

    void StartBlinking()
    {
        StopAllCoroutines();
        StartCoroutine("Blink");
    }

    void StopBlinking()
    {
        StopAllCoroutines();
    }
    public void OnTriggerEnter2D(Collider2D colliderthing)
    {
        eatsoundeffect.Play();
        PizzaEaten += 1;
        if (PizzaEaten == 3)
        {
            Counter.Score += 100;
            Counter.text.text = Counter.Score.ToString();
            GameObject childGameObject = Instantiate(Score, gameObject.transform.position, Quaternion.identity, RoundOne.transform);
            gameObject.SetActive(false);
            ScoreSound.Play();
        }
        DestroyObject(colliderthing.gameObject);
        if (gameObject.active != false)
        {
            Debug.Log("Hit");
            StartCoroutine("Eat");
            StopCoroutine("Blink");
        }

    }
}