using UnityEngine;
using UnityEngine.UI;
public class ShadowFreddy : MonoBehaviour
{
    public GameObject Freddy;
    public int AmountThrown;
    public Sprite frame1;
    public Sprite frame2;
    int framenum;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("MovementController", 0f, 0.185f);
        InvokeRepeating("SwitchFrames", 0f, 0.15f);
    }

    // Update is called once per frame
    void SwitchFrames()
    {
        if (framenum == 0)
        {
            gameObject.GetComponent<Image>().sprite = frame1;
            framenum = 1;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = frame2;
            framenum = 0;
        }
    }
    void MovementController()
    {
        if (Freddy.transform.position.y > gameObject.transform.position.y)
        {
            MoveUp();
        }
        else
        {
            MoveDown();
        }
    }
    void MoveUp()
    {
        gameObject.transform.position += new Vector3(0f, 8f, 0f);
    }
    void MoveDown()
    {
        gameObject.transform.position += new Vector3(0f, -8f, 0f);
    }
    public void OnTriggerEnter2D(Collider2D colliderthing)
    {
        AmountThrown++;
        DestroyObject(colliderthing.gameObject);
        CancelInvoke("MovementController");
        CancelInvoke("ReturnMovement");
        Invoke("ReturnMovement", 1f + AmountThrown / 10);

    }
    void ReturnMovement()
    {
        AmountThrown = 0;
        InvokeRepeating("MovementController", 0f, 0.2f);

    }
}