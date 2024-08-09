using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    int number = 3;
    public bool cooking = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Updater()
    {
        number -= 1;
        gameObject.GetComponent<Text>().text = number.ToString();
    }
}
