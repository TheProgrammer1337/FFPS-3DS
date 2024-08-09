using UnityEngine;

public class Round1Fr : MonoBehaviour
{
    public GameObject RoundTwo;
    public GameObject RoundTwoText;

    public GameObject kidone;
    public GameObject kidtwo;
    public GameObject kidthree;
    private bool done;
    // Use this for initialization
    void Start()
    {
        Resources.UnloadUnusedAssets();
    }

    // Update is called once per frame
    void Update()
    {
        if (kidone.active == false && kidtwo.active == false && kidthree.active == false && !done)
        {
            done = true;
            Invoke("RoundDelay", 1f);
        }
    }

    void RoundDelay()
    {
        RoundTwoText.SetActive(true);
        RoundTwo.SetActive(true);
        Invoke("Thing", 2f);
    }
    void Thing()
    {

        gameObject.SetActive(false);
    }
}
