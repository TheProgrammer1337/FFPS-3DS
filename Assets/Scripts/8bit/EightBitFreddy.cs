using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EightBitFreddy : MonoBehaviour
{

    public Sprite image;
    public Sprite image2;
    public GameObject Pizza1;

    public GameObject Self;



    public GameObject UpperCanvas;

    public GameObject ThrownPizza;
    public Sprite[] HeldPizzaSprites;
    public GameObject[] PizzaObjects;
    private bool[] alreadydone;
    public AudioSource music;
    public AudioSource Pickup;
    public AudioSource Throw;


    int HeldPizza;

    void Start()
    {
        image = GetComponent<Image>().sprite;
        StartBlinking();
        music.Play();
        alreadydone = new bool[PizzaObjects.Length];
    }
    void Update()
    {
        for (int i = 0; i < PizzaObjects.Length; i++)
        {
            if (!alreadydone[i] && !PizzaObjects[i].activeSelf)
            {
                StartCoroutine(PizzaRespawn(i, PizzaObjects[i]));
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (HeldPizza > 0)
            {
                Throw.Play();
                GameObject childGameObject = Instantiate(ThrownPizza, gameObject.transform.position, gameObject.transform.rotation, UpperCanvas.transform);
                childGameObject.transform.SetSiblingIndex(15);
                HeldPizza -= 1;
                if (HeldPizza == 0)
                {
                    Pizza1.SetActive(false);
                    return;
                }
                Pizza1.GetComponent<Image>().sprite = HeldPizzaSprites[HeldPizza - 1 % HeldPizzaSprites.Length] ;

            }
        }

        // MOVEMENT CODE
        {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            if (!IsInvoking("MoveLeft"))
            {
                InvokeRepeating("MoveLeft", 0f, 0.15f);
                transform.localRotation = new Quaternion(0, 10, 0, 0);
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.Keypad4))
        {
            CancelInvoke("MoveLeft");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Keypad6))
        {
            if (!IsInvoking("MoveRight"))
            {
                InvokeRepeating("MoveRight", 0f, 0.15f);
                transform.localRotation = new Quaternion(0, 0, 0, 0);
            }
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.Keypad6))
        {
            CancelInvoke("MoveRight");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Keypad8))
        {
            if (!IsInvoking("MoveUp"))
            {
                InvokeRepeating("MoveUp", 0f, 0.15f);
            }
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.Keypad8))
        {
            CancelInvoke("MoveUp");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            if (!IsInvoking("MoveDown"))
            {
                InvokeRepeating("MoveDown", 0f, 0.15f);
            }
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.Keypad2))
        {
            CancelInvoke("MoveDown");
        }
    }


    }
    void MoveLeft()
    {
        if (gameObject.transform.position.x >= 30.25f)
        {
            gameObject.transform.position += new Vector3(-10f, 0f, 0f);
        }
    }
    void MoveRight()
    {
        if (gameObject.transform.position.x <= 190.25f)
        {
            gameObject.transform.position += new Vector3(10f, 0f, 0f);

        }
    }
    void MoveUp()
    {
        if (gameObject.transform.position.y <= 210.25f)
        {
            gameObject.transform.position += new Vector3(0f, 10f, 0f);

        }
    }
    void MoveDown()
    {
        if (gameObject.transform.position.y >= 40.25f)
        {
            gameObject.transform.position += new Vector3(0f, -10f, 0f);
        }
    }

    IEnumerator Blink()
    {
        while (true)
        {

            //image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
            gameObject.GetComponent<Image>().sprite = image2;
            //Play sound
            yield return new WaitForSeconds(0.50f);
            if (gameObject.GetComponent<Image>().sprite == image2)
            {
                //image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
                gameObject.GetComponent<Image>().sprite = image;
                //Play sound
                yield return new WaitForSeconds(0.50f);
            }



        }
    }

    void StartBlinking()
    {
        StopAllCoroutines();
        StartCoroutine("Blink");
    }

    void StopBlinking()
    {
        StopAllCoroutines();
    }
    private IEnumerator PizzaRespawn(int index, GameObject Pizza)
    {
        alreadydone[index] = true;
        yield return new WaitForSeconds(2f);
        Pizza.SetActive(true);
        alreadydone[index] = false;
    }

    public void OnTriggerEnter2D(Collider2D colliderthing)
    {
        if (colliderthing.CompareTag("Pizza"))
        {
            Pickup.Play();
            colliderthing.gameObject.SetActive(false);
            if (HeldPizza <= 10)
            {
                HeldPizza += 1;

            }
            Pizza1.SetActive(true);

            Pizza1.GetComponent<Image>().sprite = HeldPizzaSprites[HeldPizza - 1];


        }

    }

   }


