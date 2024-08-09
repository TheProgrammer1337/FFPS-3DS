using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TapeRecorder : MonoBehaviour
{
    Image image;
    public int tapestate = 0;
    public GameObject ScrapBaby;
    public Sprite FrameStopped;
    public AudioSource audio;

    public Sprite PlayFrame1;
    public Sprite PlayFrame2;
    public Sprite PlayFrame3;
    public Sprite PlayFrame4;

    public Sprite StopFrame1;

    public float length;
    // Use this for initialization
    void Start()
    {
        image = GetComponent<Image>();
        audio.Play();
        audio.Pause();
        length = audio.clip.length;
    }

    // Update is called once per frame
    void Update()
    {
        if (audio.isPlaying == true)
        {
            length -= Time.deltaTime;

        }

    }
    void OnGUI()
    {
        if (GUI.Button(new Rect(107, 153, 20, 25), "", GUIStyle.none))
        {
            StartCoroutine("TapePlayAnimation");
            tapestate = 1;
            audio.UnPause();
        }
        if (GUI.Button(new Rect(137.5f, 153, 20, 25), "", GUIStyle.none))
        {

            GetComponent<Image>().sprite = FrameStopped;
            StopCoroutine("TapePlayAnimation");
            StartCoroutine("TapeStop");
            tapestate = 0;
            audio.Pause();
        }
    }
    IEnumerator TapePlayAnimation()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            gameObject.GetComponent<Image>().sprite = PlayFrame1;
            yield return new WaitForSeconds(0.05f);
            gameObject.GetComponent<Image>().sprite = PlayFrame2;
            yield return new WaitForSeconds(0.05f);
            gameObject.GetComponent<Image>().sprite = PlayFrame3;
            yield return new WaitForSeconds(0.05f);
            gameObject.GetComponent<Image>().sprite = PlayFrame4;
        }

    }
    IEnumerator TapeStop()
    {
        gameObject.GetComponent<Image>().sprite = StopFrame1;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Image>().sprite = FrameStopped;
    }
}
