using UnityEngine;
using UnityEngine.SceneManagement;

public class EightBitEnd : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        SceneManager.LoadScene(sceneName: "FirstInterrogation");
        SceneManager.UnloadSceneAsync(sceneName: "8BitMinigame");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
