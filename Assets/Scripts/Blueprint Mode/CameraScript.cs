using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float moveSpeed = 5;


    void Start()
    {

    }


    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x > -67.6033)
            {
                transform.position += Vector3.right * -moveSpeed * Time.deltaTime;

            }
        }

        if (Input.GetKey(KeyCode.Keypad6))
        {
            if (transform.position.x > -67.6033)
            {
                transform.position += Vector3.right * -moveSpeed * Time.deltaTime;

            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x < 52.6033)
            {
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.Keypad4))
        {
            if (transform.position.x < 52.6033)
            {
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (transform.position.y > -33.8871)
            {
                transform.position += Vector3.up * -moveSpeed * Time.deltaTime;

            }

        }

        if (Input.GetKey(KeyCode.Keypad8))
        {
            if (transform.position.y > -33.8871)
            {
                transform.position += Vector3.up * -moveSpeed * Time.deltaTime;

            }

        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (transform.position.y < 27.7546)
            {
                transform.position += Vector3.up * moveSpeed * Time.deltaTime;

            }

        }
        if (Input.GetKey(KeyCode.Keypad2))
        {
            if (transform.position.y < 27.7546)
            {
                transform.position += Vector3.up * moveSpeed * Time.deltaTime;

            }

        }
    }
}
