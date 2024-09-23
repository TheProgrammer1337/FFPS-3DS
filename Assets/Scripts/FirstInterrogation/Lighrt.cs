using UnityEngine;
using UnityEngine.UI;

public class Lighrt : MonoBehaviour
{
    Image image;
    public float opacity;
    public float bonus;
    public bool bonusbool;
    // Use this for initialization
    void Start()
    {
        image = gameObject.GetComponent<Image>();
        if (bonusbool == true)
        {
            InvokeRepeating("Flicker", 0f, 0.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, opacity - bonus);



    }

    void Flicker()
    {
        bonus = UnityEngine.Random.Range(0.01f, 0.1f);

    }
}
