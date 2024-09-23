using UnityEngine;
using UnityEngine.UI;

public class DuckScores : MonoBehaviour
{
    Text text;
    public int fazrating;
    public int ducks;
    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = fazrating.ToString();

    }
}
