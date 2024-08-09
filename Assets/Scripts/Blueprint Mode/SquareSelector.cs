using System.Collections;
using UnityEngine;
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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            gameObject.SetActive(false);
        }


    }

    IEnumerator Animation()
    {
        while (true)
        {
            gameObject.GetComponent<Image>().sprite = PlayFrame1;
            yield return new WaitForSeconds(0.040f);
            gameObject.GetComponent<Image>().sprite = PlayFrame2;
            yield return new WaitForSeconds(0.040f);
            gameObject.GetComponent<Image>().sprite = PlayFrame3;
            yield return new WaitForSeconds(0.040f);
            gameObject.GetComponent<Image>().sprite = PlayFrame4;
            yield return new WaitForSeconds(0.040f);
            gameObject.GetComponent<Image>().sprite = PlayFrame5;
            yield return new WaitForSeconds(0.040f);
            gameObject.GetComponent<Image>().sprite = PlayFrame4;
            yield return new WaitForSeconds(0.040f);
            gameObject.GetComponent<Image>().sprite = PlayFrame3;
            yield return new WaitForSeconds(0.040f);
            gameObject.GetComponent<Image>().sprite = PlayFrame2;
            yield return new WaitForSeconds(0.040f);
            gameObject.GetComponent<Image>().sprite = PlayFrame1;

        }

    }
}
