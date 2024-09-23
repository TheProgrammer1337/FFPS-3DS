using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Sparkles : MonoBehaviour
{
    public Sprite frame1;
    public Sprite frame2;
    public Sprite frame3;
    public Sprite frame4;
    public Sprite frame5;
    public Sprite frame6;
    public Sprite frame7;
    public Sprite frame8;
    public Sprite frame9;
    public Sprite frame10;
    public Sprite frame11;
    public Sprite frame12;
    public Sprite frame13;
    public Sprite frame14;
    public Sprite frame15;
    public Sprite frame16;
    public Sprite frame17;
    public Sprite frame18;
    public Sprite frame19;
    public Sprite frame20;
    public Sprite frame21;



    Image sprite;
    // Use this for initialization
    void Start()
    {
        sprite = gameObject.GetComponent<Image>();
        StartCoroutine("Delay");
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Delay()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f + Random.Range(0, 4f));
            int rand = Random.Range(0, 10);
            if (rand == 1)
            {
                StartCoroutine("Animation");
            }
        }
    }
    IEnumerator Animation()
    {
        yield return new WaitForSeconds(0.05f);
        sprite.sprite = frame1;
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
        yield return new WaitForSeconds(0.05f);
        sprite.sprite = frame2;
        yield return new WaitForSeconds(0.05f);
        sprite.sprite = frame3;
        yield return new WaitForSeconds(0.05f);
        sprite.sprite = frame4;
        yield return new WaitForSeconds(0.05f);
        sprite.sprite = frame5;
        yield return new WaitForSeconds(0.05f);
        sprite.sprite = frame6;
        yield return new WaitForSeconds(0.05f);
        sprite.sprite = frame7;
        yield return new WaitForSeconds(0.05f);
        sprite.sprite = frame8;
        yield return new WaitForSeconds(0.05f);
        sprite.sprite = frame9;
        yield return new WaitForSeconds(0.05f);
        sprite.sprite = frame10;
        yield return new WaitForSeconds(0.05f);
        sprite.sprite = frame11;
        yield return new WaitForSeconds(0.05f);
        sprite.sprite = frame12;
        yield return new WaitForSeconds(0.05f);
        sprite.sprite = frame13;
        yield return new WaitForSeconds(0.05f);
        sprite.sprite = frame14;
        yield return new WaitForSeconds(0.05f);
        sprite.sprite = frame15;
        yield return new WaitForSeconds(0.05f);
        sprite.sprite = frame16;
        yield return new WaitForSeconds(0.05f);
        sprite.sprite = frame17;
        yield return new WaitForSeconds(0.05f);
        sprite.sprite = frame18;
        yield return new WaitForSeconds(0.05f);
        sprite.sprite = frame19;
        yield return new WaitForSeconds(0.05f);
        sprite.sprite = frame20;
        yield return new WaitForSeconds(0.05f);
        sprite.sprite = frame21;
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0);


    }
}
