using UnityEngine;

public class FruitMaze : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localPosition -= new Vector3(1, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localPosition += new Vector3(1, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.localPosition += new Vector3(0, 1);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.localPosition += new Vector3(0, -1);
        }
    }
}
