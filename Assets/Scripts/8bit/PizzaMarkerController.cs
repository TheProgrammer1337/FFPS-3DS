using UnityEngine;
using UnityEngine.SceneManagement;

public class PizzaMarkerController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }
    int UporDown = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (UporDown == 0)
            {
                gameObject.transform.position = new Vector3(131.8f, 119.9f, 0);
                UporDown = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (UporDown == 1)
            {
                gameObject.transform.position = new Vector3(131.8f, 79.9f, 0);
                UporDown = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (UporDown == 1)
            {

                SceneManager.LoadScene("DesignPizza");
                SceneManager.UnloadSceneAsync(sceneName: "8BitMainMenu");
                

            }
            if (UporDown == 0)
            {
                SceneManager.LoadScene(sceneName: "8BitMinigame");
                SceneManager.UnloadSceneAsync(sceneName: "8BitMainMenu");
            }
        }
    }
}
