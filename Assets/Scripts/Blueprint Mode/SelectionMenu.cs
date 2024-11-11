using System.Collections.Generic;
using UnityEngine;

public class SelectionMenu : MonoBehaviour
{
    public GameObject balloonicon;
    public GameObject originalspawner;
    public GameObject discountballpiticon;
    public GameObject duckpondicon;
    public GameObject ballooncarticon;
    public GameObject candycadeticon;
    public GameObject basketballicon;
    public GameObject laddertowericon;

    public GameObject subselectionsquare;

    public SquareSelector squareSelector;

    private Dictionary<string, GameObject> iconMap;

    void Awake()
    {
        iconMap = new Dictionary<string, GameObject>
        {
            { "BalloonBarrel", balloonicon },
            { "DiscountBallPit", discountballpiticon },
            { "DuckPond", duckpondicon },
            { "BalloonCart", ballooncarticon },
            { "CandyCadet", candycadeticon },
            { "BasketBall", basketballicon },
            { "LadderTower", laddertowericon }

        };
    }

    void OnEnable()
    {
        foreach (var entry in iconMap)
        {
            entry.Value.SetActive(PlayerPrefs.GetInt(entry.Key, 0) == 0);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }

        if (Input.GetKeyDown(KeyCode.L) && Input.GetKey(KeyCode.R))
        {
            // debug
            PlayerPrefs.SetInt("BalloonCart", 0);
            Debug.Log("success");
        }
    }

    public void OnButtonClick(GameObject button)
    {
        string buttonName = button.name;
        GameObject icon;
        Debug.Log("fail");
        if (iconMap.TryGetValue(buttonName, out icon))
        {
            if (PlayerPrefs.GetInt(buttonName, 0) == 0)
            {
                ActivateBuilding(buttonName, icon);
            }
        }
    }

    private void ActivateBuilding(string buildingName, GameObject icon)
    {

        PlayerPrefs.SetString("Buildingslot" + originalspawner.GetComponent<BuildingHolder>().id, buildingName);
        subselectionsquare.gameObject.SetActive(true);
        PlayerPrefs.SetInt(buildingName, 1);

        squareSelector.ogBuilding = originalspawner.GetComponent<BuildingHolder>();

        originalspawner.GetComponent<BuildingHolder>().BuildingUsed = (BuildingHolder.BuildingType)System.Enum.Parse(typeof(BuildingHolder.BuildingType), buildingName);
        originalspawner.GetComponent<BuildingHolder>().unused = false;

        originalspawner.GetComponent<BuildingHolder>().SetSize();
        originalspawner.GetComponent<BuildingHolder>().SetSprite();

        icon.SetActive(false);
        gameObject.SetActive(false);
    }
}
