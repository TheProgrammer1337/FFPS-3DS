using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Lights : MonoBehaviour
{
    // Use this for initialization
    private Animation anim;

    void Start()
    {
        StartCoroutine("Flashing");
        anim = gameObject.GetComponent<Animation>();

    }


    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            int rand = Random.Range(0, 2);
            if (rand == 1)
            {
                if (gameObject.GetComponent<Image>().color.a == 0)
                {
                    anim.Play("comeback");
                }
                else
                {
                    anim.Play("flash");
                }
            }

        }
    }
}
