using UnityEngine;

public class Round2 : MonoBehaviour
{
    public GameObject RoundThree;
    public GameObject RoundThreeText;


    public GameObject kidone;
    public GameObject kidtwo;
    public GameObject kidthree;
    public GameObject kidfour;
    public GameObject kidfive;

    // Use this for initialization
    void Start()
    {
        Resources.UnloadUnusedAssets();
    }

    // Update is called once per frame
    void Update()
    {
        if (kidone.active == false && kidtwo.active == false && kidthree.active == false && kidfour.active == false && kidfive.active == false)
        {
            Invoke("RoundDelay", 1f);
        }
    }
    void RoundDelay()
    {
        RoundThree.SetActive(true);
        RoundThreeText.SetActive(true);
        gameObject.SetActive(false);
    }
}

