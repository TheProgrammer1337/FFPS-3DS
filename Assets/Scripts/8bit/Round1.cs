using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Round1 : MonoBehaviour
{
    Image image;
    public GameObject RoundOne;
    public AudioSource roundsound;
    public float AdjustableDelay = 2f;



    // Use this for initialization
    void Start()
    {
        image = gameObject.GetComponent<Image>();
        StartCoroutine("Startup");
    }

    public Sprite White;
    public Sprite Blue;
    public Sprite Purple;
    public Sprite Green;

    IEnumerator Blink()
    {
        while (true)
        {

            image.sprite = White;
            yield return new WaitForSeconds(0.05f);
            image.sprite = Blue;
            yield return new WaitForSeconds(0.05f);
            image.sprite = Purple;
            yield return new WaitForSeconds(0.05f);
            image.sprite = Green;

        }
    }

    void StartBlinking()
    {
        StopAllCoroutines();
        StartCoroutine("Blink");
        roundsound.Play();
    }

    void StopBlinking()
    {
        StopAllCoroutines();
        gameObject.SetActive(false);

    }
    IEnumerator Startup()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        yield return new WaitForSeconds(AdjustableDelay);
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        StartBlinking();
        Invoke("StopBlinking", 1f);
        RoundOne.SetActive(true);

    }
}
