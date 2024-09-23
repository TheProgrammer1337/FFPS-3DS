using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackgroundLight : MonoBehaviour {
	private Image image;
	// Use this for initialization
	public float mindelay;
	public float maxdelay;

	public float minalpha;
	public float maxalpha;

	void Start () {
		image = GetComponent<Image>();
		StartCoroutine("Blink");
    }
    // Update is called once per frame
	IEnumerator Blink ()
	{
		while (true)
		{
            yield return new WaitForSeconds(UnityEngine.Random.Range(mindelay, maxdelay));
            image.color = new Color(image.color.r, image.color.g, image.color.b, UnityEngine.Random.Range(minalpha, maxalpha));

        }

    }
}
