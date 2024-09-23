using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(ExecuteAfterTime(1f));
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneName: "8BitMainMenu");
        SceneManager.UnloadSceneAsync(sceneName: "8BitTitleScreen");
    }

}
