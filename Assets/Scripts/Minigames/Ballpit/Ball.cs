using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{

    Rigidbody2D rb;
    public GameObject[] ballPrefab;

    // Use this for initialization
    void Start()
    {
        int balls = 12 * PlayerPrefs.GetInt("ballpitmulti", 1);
        for (int i = 0; i < balls; i++)
        {
            GameObject ball = Instantiate(ballPrefab[UnityEngine.Random.Range(0, 4)], transform);
        }
        gameObject.SetActive(false);
    }

    void OnEnable()
    {

        foreach (Transform child in transform)
        {
            rb = child.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector3(Random.Range(-3000, 3000), Random.Range(-3600, 3600), 0));
            rb.transform.localPosition = new Vector3(Random.Range(-30, 30), 0, 0);
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
