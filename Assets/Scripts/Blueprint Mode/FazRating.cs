using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FazRating : MonoBehaviour
{
    public int RatingGain;
    public int rating;
    public int MoneyBonus;
    public int Money;
    Text text;
    public Text MoneyText;
    public AudioSource audioSource;
    public bool Override;
    // Use this for initialization
    IEnumerator Start()
    {
        Money = PlayerPrefs.GetInt("Money");
        MoneyText.text = Money.ToString();
        rating = PlayerPrefs.GetInt("FazRating");
        text = GetComponent<Text>();
        text.text = rating.ToString();
        yield return new WaitForSeconds(1.1f);
        if (PlayerPrefs.GetInt("FazRatingGain") == 0 && Override != true)
        {
            gameObject.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            RatingGain = PlayerPrefs.GetInt("FazRatingGain");
            StartCoroutine("Tickdown");
            audioSource.Play();
        }


    }

    // Update is called once per frame

    IEnumerator Tickdown()
    {
        while (RatingGain > 0)
        {

            if (RatingGain > 0)
            {
                rating += 1;
                MoneyBonus += 1;
                RatingGain -= 1;
            }
            if (RatingGain > 15)
            {
                rating += 5;
                MoneyBonus += 5;
                RatingGain -= 5;
            }
            if (RatingGain > 25)
            {
                rating += 5;
                MoneyBonus += 5;
                RatingGain -= 5;
            }
            if (RatingGain > 100)
            {
                rating += 10;
                MoneyBonus += 10;
                RatingGain -= 10;
            }
            if (RatingGain > 200)
            {
                rating += 10;
                MoneyBonus += 10;
                RatingGain -= 10;
            }
            if (RatingGain > 500)
            {
                rating += 10;
                MoneyBonus += 10;
                RatingGain -= 10;
            }
            if (RatingGain > 750)
            {
                rating += 20;
                MoneyBonus += 20;
                RatingGain -= 20;
            }
            if (RatingGain > 1000)
            {
                rating += 50;
                MoneyBonus += 50;
                RatingGain -= 50;
            }
            if (RatingGain > 5000)
            {
                rating += 50;
                MoneyBonus += 50;
                RatingGain -= 50;
            }
            if (RatingGain > 10000)
            {
                rating += 50;
                MoneyBonus += 50;
                RatingGain -= 50;
            }

            if (MoneyBonus >= 1000)
            {
                MoneyBonus -= 1000;
                Money += 100;
                MoneyText.text = Money.ToString();
            }
            text.text = rating.ToString();
            yield return new WaitForSeconds(0.05f);
        }
        audioSource.Stop();
        yield return new WaitForSeconds(5f);
        PlayerPrefs.SetInt("FazRating", rating);
        PlayerPrefs.SetInt("Money", Money);
        PlayerPrefs.SetInt("FazRatingGain", 0);
        PlayerPrefs.Save();
        gameObject.transform.parent.gameObject.SetActive(false);
    }

}
