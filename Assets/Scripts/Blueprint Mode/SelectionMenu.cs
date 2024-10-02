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
    public GameObject subselectionsquare;

    void OnEnable()
    {
        if (PlayerPrefs.GetInt("BalloonBarrel") == 0)
        {
            balloonicon.SetActive(true);
        }
        else
        {
            balloonicon.SetActive(false);
        }
        if (PlayerPrefs.GetInt("DiscountBallPit") == 0)
        {
            discountballpiticon.SetActive(true);
        }
        else
        {
            discountballpiticon.SetActive(false);
        }
        if (PlayerPrefs.GetInt("DuckPond") == 0)
        {
            duckpondicon.SetActive(true);
        }
        else
        {
            duckpondicon.SetActive(false);
        }
        if (PlayerPrefs.GetInt("BalloonCart") == 0)
        {
            ballooncarticon.SetActive(true);
        }
        else
        {
            ballooncarticon.SetActive(false);
        }
        if (PlayerPrefs.GetInt("CandyCadet") == 0)
        {
            candycadeticon.SetActive(true);
        }
        else
        {
            candycadeticon.SetActive(false);
        }
        if (PlayerPrefs.GetInt("BasketBall") == 0)
        {
            basketballicon.SetActive(true);
        }
        else
        {
            basketballicon.SetActive(false);
        }
    }

    // Update is called once per frame
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
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (Input.GetKey(KeyCode.R))
            {
                PlayerPrefs.SetInt("ballooncart", 0);
                Debug.Log("success");
            }
        }

    }


    public void OnButtonClick(GameObject button)
    {
        if (button.name == "balloonbarrel")
        {
            PlayerPrefs.SetString("Buildingslot" + originalspawner.GetComponent<BuildingHolder>().id, "BalloonBarrel");
            subselectionsquare.gameObject.SetActive(true);
            originalspawner.GetComponent<BuildingHolder>().BuildingUsed = BuildingHolder.BuildingType.BalloonBarrel;
            originalspawner.GetComponent<BuildingHolder>().unused = false;
            originalspawner.gameObject.transform.localScale = new Vector3(40, 40, 0);
            PlayerPrefs.SetInt("BalloonBarrel", 1);
            balloonicon.SetActive(false);
            gameObject.SetActive(false);
        }
        if (button.name == "ballpit")
        {
            if (PlayerPrefs.GetInt("DiscountBallPit") == 0)
            {
                subselectionsquare.gameObject.SetActive(true);
                PlayerPrefs.SetInt("DiscountBallPit", 1);
                PlayerPrefs.SetString("Buildingslot" + originalspawner.GetComponent<BuildingHolder>().id, "DiscountBallPit");
                originalspawner.GetComponent<BuildingHolder>().BuildingUsed = BuildingHolder.BuildingType.DiscountBallPit;
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
                PlayerPrefs.SetString("Buildingslot" + originalspawner.GetComponent<BuildingHolder>().id, "DuckPond");

                subselectionsquare.gameObject.SetActive(true);
                PlayerPrefs.SetInt("DuckPond", 1);
                originalspawner.GetComponent<BuildingHolder>().BuildingUsed = BuildingHolder.BuildingType.DuckPond;
                originalspawner.GetComponent<BuildingHolder>().unused = false;
                originalspawner.gameObject.transform.localScale = new Vector3(50, 55, 0);
                duckpondicon.SetActive(false);
                gameObject.SetActive(false);

            }
        }
        if (button.name == "ballooncart")
        {
            if (PlayerPrefs.GetInt("BalloonCart") == 0)
            {
                PlayerPrefs.SetString("Buildingslot" + originalspawner.GetComponent<BuildingHolder>().id, "BalloonCart");

                subselectionsquare.gameObject.SetActive(true);
                PlayerPrefs.SetInt("BalloonCart", 1);
                originalspawner.GetComponent<BuildingHolder>().BuildingUsed = BuildingHolder.BuildingType.BalloonCart;
                originalspawner.GetComponent<BuildingHolder>().unused = false;
                originalspawner.gameObject.transform.localScale = new Vector3(58.7f, 58.7f, 0);

                ballooncarticon.SetActive(false);
                gameObject.SetActive(false);

            }
        }
        if (button.name == "candycadet")
        {
            if (PlayerPrefs.GetInt("CandyCadet") == 0)
            {
                PlayerPrefs.SetString("Buildingslot" + originalspawner.GetComponent<BuildingHolder>().id, "CandyCadet");

                subselectionsquare.gameObject.SetActive(true);
                PlayerPrefs.SetInt("CandyCadet", 1);
                originalspawner.GetComponent<BuildingHolder>().BuildingUsed = BuildingHolder.BuildingType.CandyCadet;
                originalspawner.GetComponent<BuildingHolder>().unused = false;
                originalspawner.gameObject.transform.localScale = new Vector3(58.7f, 58.7f, 0);

                candycadeticon.SetActive(false);
                gameObject.SetActive(false);

            }
        }
        if (button.name == "basketball")
        {
            if (PlayerPrefs.GetInt("BasketBall") == 0)
            {
                PlayerPrefs.SetString("Buildingslot" + originalspawner.GetComponent<BuildingHolder>().id, "BasketBall");

                subselectionsquare.gameObject.SetActive(true);
                PlayerPrefs.SetInt("BasketBall", 1);
                originalspawner.GetComponent<BuildingHolder>().BuildingUsed = BuildingHolder.BuildingType.BasketBall;
                originalspawner.GetComponent<BuildingHolder>().unused = false;
                originalspawner.gameObject.transform.localScale = new Vector3(58.7f, 58.7f, 0);

                candycadeticon.SetActive(false);
                gameObject.SetActive(false);

            }
        }
        originalspawner.GetComponent<BuildingHolder>().unused = false;
        originalspawner.GetComponent<BuildingHolder>().animationPlaying = false;

        originalspawner.GetComponent<BuildingHolder>().SetSize();
        originalspawner.GetComponent<BuildingHolder>().SetSprite();


    }


}
