using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class IntroManager : MonoBehaviour {
	public float remainingtime;
	public AudioSource clip;
	public AudioClip[] clipArray;
	int counter = 0;
	// Use this for initialization
	void Start () {
		remainingtime = clip.clip.length;
		gameObject.GetComponent<Animation>().Play("Anim1");


    }
	
	// Update is called once per frame
	void Update () {
		remainingtime -= Time.deltaTime;
		if (remainingtime < 0)
		{
			counter += 1;
            try
            {
                clip.clip = clipArray[counter];
                clip.Play();
            }
            catch
            {
                SceneManager.LoadSceneAsync("Advertisement-TycoonLoader");
            }
            remainingtime = clip.clip.length;
            switch (counter)
			{
				case 1:
					gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/IntroAd/1345");
					gameObject.GetComponent<Animation>().Stop();
                    gameObject.transform.localScale = new Vector2(0.214f, 0.223f);
                    gameObject.transform.localPosition = new Vector2(3.791222f, 0f);

                    break;
                case 2:
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/IntroAd/1347");
                    gameObject.GetComponent<Animation>().Play("Anim2");
                    break;
                case 3:
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/IntroAd/1350");
                    gameObject.GetComponent<Animation>().Stop();
                    gameObject.transform.localScale = new Vector2(0.214f, 0.223f);
                    gameObject.transform.localPosition = new Vector2(3.791222f, 0f);

                    break;

                case 4:
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/IntroAd/1349");
                    break;

                case 5:
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/IntroAd/1352");
					gameObject.GetComponent<Animation>().Stop();
                    gameObject.GetComponent<Animation>().Play("Anim2");
                    break;
                case 6:
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/IntroAd/1348");
                    gameObject.GetComponent<Animation>().Play("Anim1");
                    break;
                case 7:
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/IntroAd/1351");
                    gameObject.GetComponent<Animation>().Stop();
                    gameObject.transform.localScale = new Vector2(0.214f, 0.223f);
                    gameObject.transform.localPosition = new Vector2(3.791222f, 0f);
                    break;
                case 8:
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/IntroAd/1375");
                    break;
                case 9:
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/IntroAd/1354");
                    gameObject.GetComponent<Animation>().Play("Anim1");
                    gameObject.transform.localScale = new Vector2(0.25f, 0.223f);
                    break;
                case 10:
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/IntroAd/1372");
                    gameObject.GetComponent<Animation>().Stop();
                    gameObject.GetComponent<Animation>().Play("Anim2");
                    break;
                case 11:
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/IntroAd/1355");
                    gameObject.GetComponent<Animation>().Stop();
                    gameObject.transform.localScale = new Vector2(0.214f, 0.223f);
                    gameObject.transform.localPosition = new Vector2(3.791222f, 0f);

                    break;
                case 12:
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/IntroAd/1356");
                    gameObject.GetComponent<Animation>().Stop();
                    break;
                case 13:
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/IntroAd/1357");
                    break;
                case 14:
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/IntroAd/1358");
                    break;
                case 15:
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/IntroAd/1373");
                    gameObject.GetComponent<Animation>().Play("Anim1");
                    gameObject.transform.localScale = new Vector2(0.25f, 0.223f);
                    break;
                case 16:
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/IntroAd/1359");
                    gameObject.GetComponent<Animation>().Stop();
                    gameObject.transform.localScale = new Vector2(0.214f, 0.223f);
                    gameObject.transform.localPosition = new Vector2(3.791222f, 0f);
                    break;
                case 17:
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/IntroAd/1360");
                    gameObject.GetComponent<Animation>().Stop();
                    break;
                case 18:
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/IntroAd/1361");
                    gameObject.GetComponent<Animation>().Play("Anim1");
                    gameObject.transform.localScale = new Vector2(0.25f, 0.223f);
                    break;
                case 19:
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/IntroAd/1362");
                    gameObject.GetComponent<Animation>().Stop();
                    gameObject.transform.localScale = new Vector2(0.214f, 0.223f);
                    gameObject.transform.localPosition = new Vector2(3.791222f, 0f);
                    break;
                case 20:
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/IntroAd/1364");
                    gameObject.GetComponent<Animation>().Stop();
                    break;
                case 21:
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/IntroAd/1363");
                    gameObject.GetComponent<Animation>().Stop();
                    break;
                case 22:
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/IntroAd/1365");
                    gameObject.GetComponent<Animation>().Stop();
                    break;
                case 23:
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/IntroAd/1366");
                    gameObject.GetComponent<Animation>().Stop();
                    break;
                case 24:
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/IntroAd/1367");
                    gameObject.GetComponent<Animation>().Stop();
                    break;
                case 25:
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/IntroAd/1368");
                    gameObject.GetComponent<Animation>().Stop();
                    break;
                case 26:
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/IntroAd/1369");
                    gameObject.GetComponent<Animation>().Stop();
                    break;
                case 27:
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/IntroAd/1370");
                    gameObject.GetComponent<Animation>().Stop();
                    break;
                case 28:
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/IntroAd/1371");
                    gameObject.GetComponent<Animation>().Stop();
                    break;
                default:
                    SceneManager.LoadSceneAsync("Advertisement-TycoonLoader");
                    break;
			}
            Resources.UnloadUnusedAssets();

        }
    }
}
