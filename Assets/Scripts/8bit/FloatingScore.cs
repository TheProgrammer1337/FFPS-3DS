using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FloatingScore : MonoBehaviour
{
    public Sprite[] frames;
    int counter;
    // Use this for initialization
    void Start()
    {
        StartCoroutine("Disappear");
        InvokeRepeating("MoveUp", 0f, 0.03f);
        InvokeRepeating("SwitchColors", 0f, 0.1f);
    }

    // Update is called once per frame
    void SwitchColors()
    {
        counter += 1;
        if (counter == frames.Length)
        {
            counter = 0;
        }
        gameObject.GetComponent<Image>().sprite = frames[counter];

    }
    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(0.8f);
        DestroyObject(gameObject);
    }
    void MoveUp()
    {
        gameObject.transform.position += new Vector3(0, 3, 0);
    }
}
