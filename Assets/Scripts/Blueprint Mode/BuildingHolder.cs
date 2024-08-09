using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BuildingHolder : MonoBehaviour
{
    public string BuildingUsed;

    public Sprite Frame1;
    public Sprite Frame2;
    public Sprite Frame3;
    public Sprite Frame4;
    public Sprite Frame5;
    public Sprite Frame6;
    public Sprite Frame7;
    public Sprite Frame8;
    public Sprite Frame9;
    public Sprite Frame10;
    public Sprite Frame11;
    public Sprite Frame12;
    public Sprite Frame13;
    public Sprite Frame14;
    public Sprite Frame15;
    public Sprite Frame16;
    public Sprite Frame17;
    public Sprite Frame18;
    public Sprite Frame19;
    public Sprite Frame20;

    public string id;

    public Sprite BalloonBarrel;

    public Sprite DiscountBallPit;

    public Sprite DuckPond;

    public Sprite BalloonCart;

    public Sprite CandyCadet;

    public bool balloonbarrel;
    public bool duckpond;

    public bool discountballpit;
    private bool animationPlaying = true; // New variable to track animation state

    bool done;

    public bool unused = true;


    public GameObject SelectionMenu;

    public GameObject selectionsquare;

    public GameObject subselectionsquare;

    bool instatsmenu = false;

    public Camera mainCamera; // Assign your main camera here
    public Transform objectToFollow; // Assign the object to follow here
    public void OnButtonClick(GameObject button)
    {
        if (button.name == gameObject.name)
        {
            if (unused == true)
            {
                selectionsquare.gameObject.SetActive(true);
                selectionsquare.transform.localPosition = gameObject.transform.localPosition;
                subselectionsquare.gameObject.SetActive(false);

                SelectionMenu.gameObject.SetActive(true);
                SelectionMenu.GetComponent<SelectionMenu>().originalspawner = gameObject;
            }
            if (unused == false)
            {
                SelectionMenu.gameObject.SetActive(false);
                selectionsquare.gameObject.SetActive(true);
                subselectionsquare.gameObject.SetActive(true);
                selectionsquare.transform.localPosition = gameObject.transform.localPosition;

                instatsmenu = true;

            }
        }
    }
    void OnGUI()
    {
        GUI.depth = 100;
        // Convert the object's world position to screen position

        // Create a rectangle for the button based on the screen position

        // Draw the button

        Vector3 screenPosition2 = mainCamera.WorldToScreenPoint(objectToFollow.position);
        Rect buttonRect2 = new Rect(screenPosition2.x - 95, Screen.height - screenPosition2.y - 45, 15, 15);
        if (GUI.Button(buttonRect2, "", GUIStyle.none))
        {
            if (unused == false)
            {
                PlayerPrefs.SetString("Buildingslot" + id, "none");
                PlayerPrefs.SetInt(BuildingUsed, 0);
                unused = true;

                instatsmenu = false;
                animationPlaying = true;
                BuildingUsed = "none";
                StartCoroutine("Animation");
                gameObject.transform.localScale = new Vector3(30, 30, 0);
                selectionsquare.gameObject.SetActive(false);
            }


        }
        Vector3 screenPosition3 = mainCamera.WorldToScreenPoint(objectToFollow.position);
        Rect buttonRect3 = new Rect(screenPosition3.x - 165, Screen.height - screenPosition3.y - 20, 70, 15);
        if (GUI.Button(buttonRect3, "", GUIStyle.none))
        {
            if (instatsmenu == true)
            {
                if (BuildingUsed == "duckpond")
                {
                    SceneManager.LoadScene(sceneName: "Duckpondminigame");
                    SceneManager.UnloadSceneAsync(sceneName: "Tycoon");
                }
                if (BuildingUsed == "balloonbarrel")
                {
                    SceneManager.LoadScene(sceneName: "BalloonBarrel");
                    SceneManager.UnloadSceneAsync(sceneName: "Tycoon");
                }
                if (BuildingUsed == "discountballpit")
                {
                    SceneManager.LoadScene(sceneName: "BallPit");
                    SceneManager.UnloadSceneAsync(sceneName: "Tycoon");
                }
                if (BuildingUsed == "ballooncart")
                {
                    SceneManager.LoadScene(sceneName: "BalloonCart");
                    SceneManager.UnloadSceneAsync(sceneName: "Tycoon");
                }
                if (BuildingUsed == "candycadet")
                {
                    SceneManager.LoadScene(sceneName: "CandyCadet");
                    SceneManager.UnloadSceneAsync(sceneName: "Tycoon");
                }
            }

        }

    }




    // Use this for initialization
    void Start()
    {
        BuildingUsed = PlayerPrefs.GetString("Buildingslot" + id, "none");
        if (BuildingUsed != "none")
        {
            unused = false;
            animationPlaying = false;
        }
        switch (BuildingUsed)
        {
            case "discountballpit":
                gameObject.transform.localScale = new Vector3(42, 42, 0);
                break;

            case "duckpond":
                gameObject.transform.localScale = new Vector3(50, 55, 0);
                break;

            case "balloonbarrel":
                gameObject.transform.localScale = new Vector3(40, 40, 0);
                break;

            case "ballooncart":
                gameObject.transform.localScale = new Vector3(58.7f, 58.7f, 0);
                break;

            case "candycadet":
                gameObject.transform.localScale = new Vector3(58.7f, 58.7f, 0);
                break;

            default:
                gameObject.transform.localScale = new Vector3(30, 30, 0);
                break;
        }

        StartCoroutine("Animation");
    }

    // Update is called once per frame
    void Update()
    {

        switch (BuildingUsed)
        {
            case "balloonbarrel":
                gameObject.GetComponent<Image>().sprite = BalloonBarrel;
                break;

            case "discountballpit":
                gameObject.GetComponent<Image>().sprite = DiscountBallPit;
                break;

            case "duckpond":
                gameObject.GetComponent<Image>().sprite = DuckPond;
                break;

            case "ballooncart":
                gameObject.GetComponent<Image>().sprite = BalloonCart;
                break;

            case "candycadet":
                gameObject.GetComponent<Image>().sprite = CandyCadet;
                break;

            case "none":
                break;

            default:
                break;
        }


    }
    public IEnumerator Animation()
    {
        while (true) // Keep the animation loop running indefinitely
        {
            if (unused) // Only play the animation if no item is assigned
            {
                gameObject.GetComponent<Image>().sprite = Frame1;
                yield return new WaitForSeconds(0.02f);
                gameObject.GetComponent<Image>().sprite = Frame2;
                yield return new WaitForSeconds(0.02f);
                gameObject.GetComponent<Image>().sprite = Frame3;
                yield return new WaitForSeconds(0.02f);
                gameObject.GetComponent<Image>().sprite = Frame4;
                yield return new WaitForSeconds(0.02f);
                gameObject.GetComponent<Image>().sprite = Frame5;
                yield return new WaitForSeconds(0.02f);
                gameObject.GetComponent<Image>().sprite = Frame7;
                yield return new WaitForSeconds(0.02f);
                gameObject.GetComponent<Image>().sprite = Frame8;
                yield return new WaitForSeconds(0.02f);
                gameObject.GetComponent<Image>().sprite = Frame9;
                yield return new WaitForSeconds(0.02f);
                gameObject.GetComponent<Image>().sprite = Frame10;
                yield return new WaitForSeconds(0.02f);
                gameObject.GetComponent<Image>().sprite = Frame11;
                yield return new WaitForSeconds(0.02f);
                gameObject.GetComponent<Image>().sprite = Frame12;
                yield return new WaitForSeconds(0.02f);
                gameObject.GetComponent<Image>().sprite = Frame13;
                yield return new WaitForSeconds(0.02f);
                gameObject.GetComponent<Image>().sprite = Frame14;
                yield return new WaitForSeconds(0.02f);
                gameObject.GetComponent<Image>().sprite = Frame15;
                yield return new WaitForSeconds(0.02f);
                gameObject.GetComponent<Image>().sprite = Frame16;
                yield return new WaitForSeconds(0.02f);
                gameObject.GetComponent<Image>().sprite = Frame17;
                yield return new WaitForSeconds(0.02f);
                gameObject.GetComponent<Image>().sprite = Frame18;
                yield return new WaitForSeconds(0.02f);
                gameObject.GetComponent<Image>().sprite = Frame19;
                yield return new WaitForSeconds(0.02f);
                gameObject.GetComponent<Image>().sprite = Frame20;
            }
            else
            {
                // If an item is assigned, stop the animation
                animationPlaying = false;
            }

            // Wait for the next frame
            yield return new WaitForSeconds(0.02f);

            // If the animation is not playing, break out of the loop
            if (!animationPlaying)
            {
                break;
            }
        }
    }
}
