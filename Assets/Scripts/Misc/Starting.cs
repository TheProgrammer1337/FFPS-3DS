using UnityEngine;
using UnityEngine.SceneManagement;

public class Starting : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetInt("HasCompleted8BitIntro", 0) == 1)
        {
            SceneManager.LoadScene(sceneName: "RealTitleScreen");
            SceneManager.UnloadSceneAsync(sceneName: "Start");
        }
        else
        {
            SceneManager.LoadScene(sceneName: "8BitTitleScreen");
            SceneManager.UnloadSceneAsync(sceneName: "Start");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
