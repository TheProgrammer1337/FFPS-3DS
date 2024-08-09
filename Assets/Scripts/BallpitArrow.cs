using UnityEngine;

public class BallpitArrow : MonoBehaviour
{
    bool left = true;
    public bool going = true;
    // Use this for initialization
    public int speed = 20;
    // Update is called once per frame
    void Update()
    {
        if (left && going)
        {
            if (gameObject.transform.localPosition.x > -200f)
            {
                gameObject.transform.localPosition += new Vector3(-speed, 0, 0);
            }
            else
            {
                left = false;
            }
        }
        else if (!left && going)
        {
            if (gameObject.transform.localPosition.x < 200f)
            {
                gameObject.transform.localPosition += new Vector3(speed, 0, 0);
            }
            else
            {
                left = true;
            }
        }
    }


}
