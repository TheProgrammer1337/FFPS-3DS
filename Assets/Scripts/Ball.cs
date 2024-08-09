using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{

    Rigidbody2D rb;
    // Use this for initialization
    void OnEnable()
    {
        foreach (Transform child in transform)
        {
            child.transform.localPosition = new Vector3();
        }
        foreach (Transform child in transform)
        {
            rb = child.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector3(Random.Range(-3000, 3000), Random.Range(-3600, 3600), 0));
            rb.gameObject.transform.localPosition += new Vector3(Random.Range(-30, 30), 0, 0);
        }
        StartCoroutine("Delay");


    }


    // Update is called once per frame

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);

        gameObject.SetActive(false);

    }
}
