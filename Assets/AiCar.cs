using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AiCar : MonoBehaviour
{
    public bool left;
    public Car car;
    private Image image;
    // Use this for initialization
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (left)
        {
            transform.localPosition += new Vector3(-1 - car.speed / 30, 0);
            if (transform.localPosition.x > 999.625)
            {
                transform.localPosition = new Vector3(-0.025f, transform.localPosition.y);
                gameObject.GetComponent<Collider2D>().enabled = true;
                image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
            }
            if (transform.localPosition.x < -699.625f)
            {
                transform.localPosition = new Vector3(390, transform.localPosition.y);
                gameObject.GetComponent<Collider2D>().enabled = true;
                image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
            }
        }
        else
        {
            transform.localPosition += new Vector3(1 - car.speed / 30, 0);
            if (transform.localPosition.x > 999.625f)
            {
                transform.localPosition = new Vector3(-0.025f, transform.localPosition.y);
                gameObject.GetComponent<Collider2D>().enabled = true;
                image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
            }
            if (transform.localPosition.x < -699.625f)
            {
                transform.localPosition = new Vector3(390, transform.localPosition.y);
                gameObject.GetComponent<Collider2D>().enabled = true;
                image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
            }
        }
    }
    IEnumerator GoInvisible()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        gameObject.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(0f);



    }

}
