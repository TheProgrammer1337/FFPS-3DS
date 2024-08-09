using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Duck : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine("Animation");
        objectToFollow = gameObject.transform;
        speed = UnityEngine.Random.Range(0.10f, 0.25f);
        myStyle.fontSize = 18;
    }

    // Update is called once per frame

    public Camera mainCamera; // Assign your main camera here
    public Transform objectToFollow; // Assign the object to follow here
    GUIStyle myStyle = new GUIStyle();

    float speed;
    float speed2 = 0.035f;
    public Sprite Frame1;
    public Sprite Frame2;
    public Sprite Frame3;
    public Sprite Frame4;
    public Sprite Frame5;
    public Sprite Frame6;
    public Sprite Frame7;

    public Sprite score1;
    public Sprite score5;
    public Sprite score9;

    int fazrating;
    int ducks;

    public Sprite PickupFrame1;
    public Sprite PickupFrame2;
    public Sprite PickupFrame3;
    public Sprite PickupFrame4;
    public Sprite PickupFrame5;
    public Sprite PickupFrame6;
    public Sprite PickupFrame7;
    public Sprite PickupFrame8;
    public Sprite PickupFrame9;
    public Sprite PickupFrame10;
    public Sprite PickupFrame11;
    public Counter counter;

    public AudioSource score;

    public GameObject scorecounter;

    public DuckScores duckscore;

    GUIStyle GGUIStyle = GUIStyle.none;

    void OnGUI()
    {
        Vector3 screenPosition2 = mainCamera.WorldToScreenPoint(objectToFollow.position);
        Rect buttonRect2 = new Rect(screenPosition2.x - 18, Screen.height - screenPosition2.y - 20, 36, 36);
        if (GUI.Button(buttonRect2, "", GGUIStyle))
        {
            if (counter.cooking == false)
            {
                StartCoroutine("PickupAnimation");
                StopCoroutine("Animation");
                counter.Updater();
            }

        }


    }
    public IEnumerator Animation()
    {
        while (true) // Keep the animation loop running indefinitely
        {
            gameObject.GetComponent<Image>().sprite = Frame1;
            yield return new WaitForSeconds(speed);
            gameObject.GetComponent<Image>().sprite = Frame2;
            yield return new WaitForSeconds(speed);
            gameObject.GetComponent<Image>().sprite = Frame3;
            yield return new WaitForSeconds(speed);
            gameObject.GetComponent<Image>().sprite = Frame4;
            yield return new WaitForSeconds(speed);
            gameObject.GetComponent<Image>().sprite = Frame5;
            yield return new WaitForSeconds(speed);
            gameObject.GetComponent<Image>().sprite = Frame6;
            yield return new WaitForSeconds(speed);
            gameObject.GetComponent<Image>().sprite = Frame5;
            yield return new WaitForSeconds(speed);
            gameObject.GetComponent<Image>().sprite = Frame4;
            yield return new WaitForSeconds(speed);
            gameObject.GetComponent<Image>().sprite = Frame3;
            yield return new WaitForSeconds(speed);
            gameObject.GetComponent<Image>().sprite = Frame2;
            yield return new WaitForSeconds(speed);

        }
    }
    public IEnumerator PickupAnimation()
    {
        counter.cooking = true;
        gameObject.transform.SetAsLastSibling();
        gameObject.GetComponent<Image>().sprite = PickupFrame1;
        yield return new WaitForSeconds(speed2);
        gameObject.transform.localScale = new Vector3(40, 40);
        gameObject.GetComponent<Image>().sprite = PickupFrame2;
        yield return new WaitForSeconds(speed2);
        gameObject.transform.localScale = new Vector3(50, 50);
        gameObject.GetComponent<Image>().sprite = PickupFrame3;
        gameObject.transform.localScale = new Vector3(60, 60);
        yield return new WaitForSeconds(speed2);
        gameObject.GetComponent<Image>().sprite = PickupFrame4;
        gameObject.transform.localScale = new Vector3(70, 70);
        yield return new WaitForSeconds(speed2);
        gameObject.GetComponent<Image>().sprite = PickupFrame5;
        gameObject.transform.localScale = new Vector3(80, 80);
        yield return new WaitForSeconds(speed2);
        gameObject.transform.localScale = new Vector3(80, 120);
        gameObject.GetComponent<Image>().sprite = PickupFrame7;
        yield return new WaitForSeconds(speed2);
        gameObject.GetComponent<Image>().sprite = PickupFrame8;
        yield return new WaitForSeconds(speed2);
        gameObject.GetComponent<Image>().sprite = PickupFrame9;
        yield return new WaitForSeconds(speed2);
        gameObject.GetComponent<Image>().sprite = PickupFrame10;
        yield return new WaitForSeconds(speed2);
        gameObject.GetComponent<Image>().sprite = PickupFrame11;
        score.Play();
        scorecounter.gameObject.SetActive(true);
        scorecounter.transform.localPosition = new Vector3(gameObject.transform.localPosition.x - 17.5f, gameObject.transform.localPosition.y - 8);
        int rand = UnityEngine.Random.Range(0, 100);
        if (rand < 81) // 81% chance
        {
            scorecounter.GetComponent<Image>().sprite = score1;
            duckscore.fazrating += 100;
        }
        else if (rand >= 81 && rand < 99) // 18% chance
        {
            scorecounter.GetComponent<Image>().sprite = score5;
            duckscore.fazrating += 500;
        }
        else if (rand >= 99) // 1% chance
        {
            scorecounter.GetComponent<Image>().sprite = score9;
            duckscore.fazrating += 900;
        }
        scorecounter.transform.SetAsLastSibling();
        yield return new WaitForSeconds(1.7f);
        duckscore.ducks += 1;
        if (duckscore.ducks == 3)
        {
            SceneManager.LoadScene("Tycoon");
            PlayerPrefs.SetInt("FazRatingGain", duckscore.fazrating);

        }
        scorecounter.gameObject.SetActive(false);
        counter.cooking = false;
        Destroy(gameObject);


    }

}
