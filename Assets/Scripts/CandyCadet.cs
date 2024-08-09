using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CandyCadet : MonoBehaviour
{
    public Sprite frame1;
    public Sprite frame2;
    public Sprite frame3;
    public Sprite frame4;
    public Sprite frame5;
    public Sprite frame6;
    public GameObject candy;
    public float speed;
    public AudioSource nextime;
    public AudioSource music;
    public AudioSource twinkle;
    public GameObject pressa;
    public Text text;
    public GameObject wintext;
    public GameObject airhorn;
    int fazrating;
    // Use this for initialization
    void Start()
    {
        StartCoroutine("Animation");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine("Candy");
            candy.SetActive(true);
            twinkle.gameObject.SetActive(true);
            pressa.gameObject.SetActive(false);
            fazrating = 250 * Random.Range(1, 9);
            PlayerPrefs.SetInt("FazRatingGain", fazrating);
            text.text = fazrating.ToString();
        }
    }
    IEnumerator Candy()
    {
        while (candy.transform.localPosition.y > -53.1f)
        {
            yield return new WaitForSeconds(0.01f);
            candy.transform.localPosition -= new Vector3(0, 2.3f);
        }
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        text.gameObject.SetActive(false);
        music.Stop();
        Destroy(candy);
        nextime.gameObject.SetActive(true);
        while (nextime.time <= 3.7f)
        {
            yield return new WaitForSeconds(0.05f);
            gameObject.transform.localScale += new Vector3(0.08f, 0.08f);

        }
        yield return new WaitForSeconds(0.1f);
        wintext.gameObject.SetActive(true);
        airhorn.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneName: "Tycoon");
        SceneManager.UnloadSceneAsync(sceneName: "CandyCadet");
    }

    IEnumerator Animation()
    {
        while (true)
        {
            yield return new WaitForSeconds(speed);
            gameObject.GetComponent<Image>().sprite = frame1;
            yield return new WaitForSeconds(speed);
            gameObject.GetComponent<Image>().sprite = frame2;
            yield return new WaitForSeconds(speed);
            gameObject.GetComponent<Image>().sprite = frame3;
            yield return new WaitForSeconds(speed);
            gameObject.GetComponent<Image>().sprite = frame4;
            yield return new WaitForSeconds(speed);
            gameObject.GetComponent<Image>().sprite = frame5;
            yield return new WaitForSeconds(speed);
            gameObject.GetComponent<Image>().sprite = frame6;
        }
    }
}
