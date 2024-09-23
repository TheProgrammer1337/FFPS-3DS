using UnityEngine;

public class BallPitStopper : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }
    bool left = false;
    // Update is called once per frame
    void Update()
    {
        if (left == true)
        {
            gameObject.transform.localPosition -= new Vector3(1, 0);
            if (transform.localPosition.x < -72.5f)
            {
                left = false;
            }
        }
        else
        {
            gameObject.transform.localPosition -= new Vector3(-1, 0);
            if (transform.localPosition.x > 75.4)
            {
                left = true;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        collider.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        collider.GetComponent<Rigidbody2D>().isKinematic = false;
        collider.GetComponent<Rigidbody2D>().AddForce(new Vector3(200, 200));
    }
}
