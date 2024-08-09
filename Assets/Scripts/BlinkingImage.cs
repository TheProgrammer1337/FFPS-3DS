using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingImage : MonoBehaviour
{
    public bool bol = false;
    Image image;
    public Sprite sprite;
    public float speed = 0.25f;
    void OnEnable()
    {
        image = GetComponent<Image>();
        StartBlinking();
        if (bol == true)
        {
            StartCoroutine("Text");
        }
    }


    IEnumerator Blink()
    {
        while (true)
        {
            switch (image.color.a.ToString())
            {
                case "0":
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
                    //Play sound
                    yield return new WaitForSeconds(speed);
                    if (bol == true)
                    {
                        yield return new WaitForSeconds(0.10f);
                    }
                    break;
                case "1":
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
                    //Play sound
                    yield return new WaitForSeconds(speed);
                    if (bol == true)
                    {
                        yield return new WaitForSeconds(0.10f);
                    }
                    break;
            }
        }
    }
    IEnumerator Text()
    {
        yield return new WaitForSeconds(3f);
        speed = 0.025f;
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        gameObject.transform.localScale = new Vector3(12, gameObject.transform.localScale.y);
        gameObject.GetComponent<Image>().sprite = sprite;
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);

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

}