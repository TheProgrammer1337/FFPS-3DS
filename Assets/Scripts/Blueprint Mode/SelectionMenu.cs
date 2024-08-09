using UnityEngine;

public class SelectionMenu : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {




    }
    void OnEnable()
    {
        if (PlayerPrefs.GetInt("balloonbarrel") == 0)
        {
            balloonicon.SetActive(true);
        }
        else
        {
            balloonicon.SetActive(false);
        }
        if (PlayerPrefs.GetInt("discountballpit") == 0)
        {
            discountballpiticon.SetActive(true);
        }
        else
        {
            discountballpiticon.SetActive(false);
        }
        if (PlayerPrefs.GetInt("duckpond") == 0)
        {
            duckpondicon.SetActive(true);
        }
        else
        {
            duckpondicon.SetActive(false);
        }
        if (PlayerPrefs.GetInt("ballooncart") == 0)
        {
            ballooncarticon.SetActive(true);
        }
        else
        {
            ballooncarticon.SetActive(false);
        }
        if (PlayerPrefs.GetInt("candycadet") == 0)
        {
            candycadeticon.SetActive(true);
        }
        else
        {
            candycadeticon.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            PlayerPrefs.DeleteAll();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (Input.GetKey(KeyCode.R))
            {
                PlayerPrefs.SetInt("ballooncart", 0);
                Debug.Log("success");
            }
        }

    }

    public GameObject balloonicon;

    public GameObject originalspawner;

    public GameObject discountballpiticon;
    public GameObject duckpondicon;
    public GameObject ballooncarticon;
    public GameObject candycadeticon;
    public GameObject subselectionsquare;
    public void OnButtonClick(GameObject button)
    {
        if (button.name == "balloonbarrel")
        {
            PlayerPrefs.SetString("Buildingslot" + originalspawner.GetComponent<BuildingHolder>().id, "balloonbarrel");
            subselectionsquare.gameObject.SetActive(true);
            originalspawner.GetComponent<BuildingHolder>().BuildingUsed = "balloonbarrel";
            originalspawner.GetComponent<BuildingHolder>().unused = false;
            originalspawner.gameObject.transform.localScale = new Vector3(40, 40, 0);
            PlayerPrefs.SetInt("balloonbarrel", 1);
            balloonicon.SetActive(false);
            gameObject.SetActive(false);
        }
        if (button.name == "ballpit")
        {
            if (PlayerPrefs.GetInt("discountballpit") == 0)
            {
                subselectionsquare.gameObject.SetActive(true);
                PlayerPrefs.SetInt("discountballpit", 1);
                PlayerPrefs.SetString("Buildingslot" + originalspawner.GetComponent<BuildingHolder>().id, "discountballpit");
                originalspawner.GetComponent<BuildingHolder>().BuildingUsed = "discountballpit";
                originalspawner.GetComponent<BuildingHolder>().unused = false;
                originalspawner.gameObject.transform.localScale = new Vector3(42, 42, 0);
                discountballpiticon.SetActive(false);
                gameObject.SetActive(false);

            }
        }
        if (button.name == "duckpond")
        {
            if (PlayerPrefs.GetInt("duckpond") == 0)
            {
                PlayerPrefs.SetString("Buildingslot" + originalspawner.GetComponent<BuildingHolder>().id, "duckpond");

                subselectionsquare.gameObject.SetActive(true);
                PlayerPrefs.SetInt("duckpond", 1);
                originalspawner.GetComponent<BuildingHolder>().BuildingUsed = "duckpond";
                originalspawner.GetComponent<BuildingHolder>().unused = false;
                originalspawner.gameObject.transform.localScale = new Vector3(50, 55, 0);
                duckpondicon.SetActive(false);
                gameObject.SetActive(false);

            }
        }
        if (button.name == "ballooncart")
        {
            if (PlayerPrefs.GetInt("ballooncart") == 0)
            {
                PlayerPrefs.SetString("Buildingslot" + originalspawner.GetComponent<BuildingHolder>().id, "ballooncart");

                subselectionsquare.gameObject.SetActive(true);
                PlayerPrefs.SetInt("ballooncart", 1);
                originalspawner.GetComponent<BuildingHolder>().BuildingUsed = "ballooncart";
                originalspawner.GetComponent<BuildingHolder>().unused = false;
                originalspawner.gameObject.transform.localScale = new Vector3(58.7f, 58.7f, 0);

                ballooncarticon.SetActive(false);
                gameObject.SetActive(false);

            }
        }
        if (button.name == "candycadet")
        {
            if (PlayerPrefs.GetInt("candycadet") == 0)
            {
                PlayerPrefs.SetString("Buildingslot" + originalspawner.GetComponent<BuildingHolder>().id, "candycadet");

                subselectionsquare.gameObject.SetActive(true);
                PlayerPrefs.SetInt("candycadet", 1);
                originalspawner.GetComponent<BuildingHolder>().BuildingUsed = "candycadet";
                originalspawner.GetComponent<BuildingHolder>().unused = false;
                originalspawner.gameObject.transform.localScale = new Vector3(58.7f, 58.7f, 0);

                candycadeticon.SetActive(false);
                gameObject.SetActive(false);

            }
        }

    }


}
