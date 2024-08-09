using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Car : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine("Speedup");
    }
    public int speed;
    public Transform road;
    public Text counter;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.localPosition.x > -184.1f)
            {
                gameObject.transform.localPosition += new Vector3(-2f, 0, 0);

            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.localPosition.x < 185.3f)
            {
                gameObject.transform.localPosition += new Vector3(2f, 0, 0);
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (transform.localPosition.y > -98.2f)
                gameObject.transform.localPosition += new Vector3(0, -2f, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (transform.localPosition.y < 97.7f)
            {
                gameObject.transform.localPosition += new Vector3(0, 2f, 0);
            }
        }

        road.localPosition -= new Vector3(1 + speed / 40, 0);
        if (road.localPosition.x < -399)
        {
            road.localPosition = new Vector3(-0.25249f, 0);
        }

        if (new N3dsPausedReason() == N3dsPausedReason.ClosingTheLid)
        {
            speed += 1;
        }
    }


    IEnumerator Speedup()
    {

        while (speed < 200)
        {
            if (speed < 150)
            {
                yield return new WaitForSeconds(0.05f);
                speed += 1;
                counter.text = "MPH " + speed.ToString();
            }
            else if (speed < 200)
            {
                yield return new WaitForSeconds(0.2f);
                speed += 1;
                counter.text = "MPH " + speed.ToString();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        speed = 0;
        StopCoroutine("Speedup");
        StartCoroutine("Speedup");
        collision.GetComponent<AiCar>().StartCoroutine("GoInvisible");
    }

}
