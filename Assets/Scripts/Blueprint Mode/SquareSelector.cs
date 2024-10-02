using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SquareSelector : MonoBehaviour
{

    // Use this for initialization
    void OnEnable()
    {

        StartCoroutine("Animation");
    }
    Vector3 vector3 = Vector3.zero;
    // Update is called once per frame
    public Sprite PlayFrame1;
    public Sprite PlayFrame2;

    public Sprite PlayFrame3;
    public Sprite PlayFrame4;
    public Sprite PlayFrame5;
    public Sprite PlayFrame6;
    public BuildingHolder ogBuilding;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            gameObject.SetActive(false);
        }


    }
    public void onButtonClicked(string buttonthing)
    {
        if (buttonthing == "X")
        {
            ogBuilding.RemoveBuilding();
        }
        if (buttonthing == "Play")
        {
            switch (ogBuilding.BuildingUsed)
            {
                case BuildingHolder.BuildingType.DuckPond:
                    SceneManager.LoadScene("Duckpondminigame");
                    SceneManager.UnloadSceneAsync("Tycoon");
                    break;
                case BuildingHolder.BuildingType.BalloonBarrel:
                    SceneManager.LoadScene("BalloonBarrel");
                    SceneManager.UnloadSceneAsync("Tycoon");
                    break;
                case BuildingHolder.BuildingType.DiscountBallPit:
                    SceneManager.LoadScene("BallPit");
                    SceneManager.UnloadSceneAsync("Tycoon");
                    break;
                case BuildingHolder.BuildingType.BalloonCart:
                    SceneManager.LoadScene("BalloonCart");
                    SceneManager.UnloadSceneAsync("Tycoon");
                    break;
                case BuildingHolder.BuildingType.CandyCadet:
                    SceneManager.LoadScene("CandyCadet");
                    SceneManager.UnloadSceneAsync("Tycoon");
                    break;
                case BuildingHolder.BuildingType.BasketBall:
                    SceneManager.LoadScene("BasketBall");
                    SceneManager.UnloadSceneAsync("Tycoon");
                    break;
            }
        }
    
    }
    IEnumerator Animation()
    {
        Image image = gameObject.GetComponent<Image>();
        while (true)
        {
            image.sprite = PlayFrame1;
            yield return new WaitForSeconds(0.040f);
            image.sprite = PlayFrame2;
            yield return new WaitForSeconds(0.040f);
            image.sprite = PlayFrame3;
            yield return new WaitForSeconds(0.040f);
            image.sprite = PlayFrame4;
            yield return new WaitForSeconds(0.040f);
            image.sprite = PlayFrame5;
            yield return new WaitForSeconds(0.040f);
            image.sprite = PlayFrame4;
            yield return new WaitForSeconds(0.040f);
            image.sprite = PlayFrame3;
            yield return new WaitForSeconds(0.040f);
            image.sprite = PlayFrame2;
            yield return new WaitForSeconds(0.040f);
            image.sprite = PlayFrame1;

        }

    }
}
