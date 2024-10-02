using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour
{
    public bool bol = false;
    Text image;
    public float speed = 0.25f;
    void OnEnable()
    {
        image = GetComponent<Text>();
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
        image.text = "GO!!!";
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