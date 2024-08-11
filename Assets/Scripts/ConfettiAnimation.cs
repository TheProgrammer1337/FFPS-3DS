using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ConfettiAnimation : MonoBehaviour
{

    public Sprite frame33;
    public Sprite frame34;
    public Sprite frame35;
    public Sprite frame36;
    public Sprite frame37;
    public Sprite frame38;
    public Sprite frame39;
    public Sprite frame40;
    public Sprite frame41;
    public Sprite frame42;
    public Sprite frame43;
    public Sprite frame44;
    public Sprite frame45;
    public Sprite frame46;
    public Sprite frame47;
    public Sprite frame48;
    public Sprite frame49;
    public Sprite frame50;
    public Sprite frame51;
    public Sprite frame52;
    public Sprite frame53;
    public Sprite frame54;
    public Sprite frame55;
    public Sprite frame56;
    public Sprite frame57;
    public Sprite frame58;
    public Sprite frame59;
    public Sprite frame60;
    public Sprite frame61;
    public Sprite frame62;
    Image sprite;
    // Use this for initialization
    void Start()
    {
        sprite = gameObject.GetComponent<Image>();
        StartCoroutine("Animation");
        gameObject.transform.SetSiblingIndex(2);

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localPosition.y < -130)
        {
            gameObject.transform.localPosition = new Vector3(Random.Range(-200, 200), 130);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        }
    }
    IEnumerator Animation()
    {
        while (true)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -30, 0);
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame33;
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame34;
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame35;
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame36;
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame37;
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame38;
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame39;
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame40;
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame41;
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame42;
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame43;
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame44;
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame45;
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame46;
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame47;
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame48;
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame49;
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame50;
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame51;
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame52;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -30, 0);
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame53;
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame54;
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame55;
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame56;
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame57;
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame58;
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame59;
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame60;
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame61;
            yield return new WaitForSeconds(0.05f);
            sprite.sprite = frame62;
        }

    }
}
