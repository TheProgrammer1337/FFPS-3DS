using System.Collections;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BuildingHolder : MonoBehaviour
{
    public enum BuildingType
    {
        None,
        BalloonBarrel,
        DiscountBallPit,
        DuckPond,
        BalloonCart,
        CandyCadet
    }

    public BuildingType BuildingUsed;
    public Sprite[] DefaultAnimation;

    public string id;

    public bool left; //0 = left 1 = right

    public bool animationPlaying = true;

    public bool unused = true;

    public GameObject SelectionMenu;
    public GameObject selectionsquare;
    public GameObject subselectionsquare;

    bool instatsmenu = false;
    public Camera mainCamera; 
    public Transform objectToFollow;


    public void OnButtonClick(GameObject button)
    {
        if (unused)
        {
            selectionsquare.gameObject.SetActive(true);
            selectionsquare.transform.localPosition = gameObject.transform.localPosition;
            subselectionsquare.gameObject.SetActive(false);

            SelectionMenu.gameObject.SetActive(true);
            SelectionMenu.GetComponent<SelectionMenu>().originalspawner = gameObject;
        }
        else
        {
            SelectionMenu.gameObject.SetActive(false);
            selectionsquare.gameObject.SetActive(true);
            subselectionsquare.gameObject.SetActive(true);
            selectionsquare.transform.localPosition = gameObject.transform.localPosition;

            selectionsquare.GetComponent<SquareSelector>().ogBuilding = GetComponent<BuildingHolder>();

            instatsmenu = true;
        }
    }
    public void RemoveBuilding()
    {
        PlayerPrefs.SetString("Buildingslot" + id, BuildingType.None.ToString());
        PlayerPrefs.SetInt(BuildingUsed.ToString(), 0);
        unused = true;

        instatsmenu = false;
        animationPlaying = true;
        BuildingUsed = BuildingType.None;
        StartCoroutine("Animation");
        gameObject.transform.localScale = new Vector3(30, 30, 0);
        selectionsquare.gameObject.SetActive(false);
    }
    public void SetSize()
    {
        switch (BuildingUsed)
        {
            case BuildingType.DiscountBallPit:
                gameObject.transform.localScale = new Vector3(42, 42, 0);
                break;
            case BuildingType.DuckPond:
                gameObject.transform.localScale = new Vector3(50, 55, 0);
                break;
            case BuildingType.BalloonBarrel:
                gameObject.transform.localScale = new Vector3(40, 40, 0);
                break;
            case BuildingType.BalloonCart:
                gameObject.transform.localScale = new Vector3(58.7f, 58.7f, 0);
                break;
            case BuildingType.CandyCadet:
                gameObject.transform.localScale = new Vector3(58.7f, 58.7f, 0);
                break;
            default:
                gameObject.transform.localScale = new Vector3(30, 30, 0);
                break;
        }

    }
    public void SetSprite()
    {
        Image image = gameObject.GetComponent<Image>();
        switch (BuildingUsed)
        {
            case BuildingType.BalloonBarrel:
                image.sprite = Resources.Load<Sprite>("Sprites/BlueprintMode/Buildings/BalloonBarrel") as Sprite;
                break;
            case BuildingType.DiscountBallPit:
                image.sprite = Resources.Load<Sprite>("Sprites/BlueprintMode/Buildings/BallPit");
                break;
            case BuildingType.DuckPond:
                image.sprite = Resources.Load<Sprite>("Sprites/BlueprintMode/Buildings/DuckPond") as Sprite;
                break;
            case BuildingType.BalloonCart:
                image.sprite = Resources.Load<Sprite>("Sprites/BlueprintMode/Buildings/BalloonCart") as Sprite;
                break;
            case BuildingType.CandyCadet:
                if (left == true) 
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/BlueprintMode/Buildings/CCLeft") as Sprite;
                }
                else
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/BlueprintMode/Buildings/CCRight") as Sprite;
                }
                break;
            case BuildingType.None:
                break;
        }
    }
    void Start()
    {

        BuildingUsed = (BuildingType)System.Enum.Parse(typeof(BuildingType), PlayerPrefs.GetString("Buildingslot" + id, "None"), true);
        if (BuildingUsed != BuildingType.None)
        {
            unused = false;
            animationPlaying = false;
        }
        SetSprite();
        SetSize();

        StartCoroutine("Animation");
    }

    void Update()
    {
        if (instatsmenu == true)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                RemoveBuilding();
            }
        }

    }

    public IEnumerator Animation()
    {
        Image imageComponent = gameObject.GetComponent<Image>();

        while (animationPlaying)
        {
            if (unused)
            {
                for (int i = 0; i < DefaultAnimation.Length; i++)
                {
                    if (!unused)
                    {
                        yield break;
                    }
                    imageComponent.sprite = DefaultAnimation[i];
                    yield return new WaitForSeconds(0.02f);
                }
            }
            else
            {
                animationPlaying = false;
            }

            yield return new WaitForEndOfFrame();
        }
    }
}