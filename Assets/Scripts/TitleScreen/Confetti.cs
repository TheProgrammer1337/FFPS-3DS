using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Confetti : MonoBehaviour
{
    public GameObject confetti;
    public GameObject UpperCanvas;
    int spawned = 0;
    // Use this for initialization
    void Start()
    {
        StartCoroutine("ConfettiSpawning");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene(sceneName: "Tycoon");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
    IEnumerator ConfettiSpawning()
    {
        while (spawned < 15)
        {
            yield return new WaitForSeconds(1);
            Instantiate(confetti, new Vector3(Random.Range(0, 400), 300 + Random.Range(0, 80), 0), Quaternion.identity, UpperCanvas.transform);
            spawned += 1;
        }
    }
    //IEnumerator Instantiate ()
    //{

    //}
}
