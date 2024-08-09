using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EightBitFreddy : MonoBehaviour
{

    public Sprite image;
    public Sprite image2;
    public GameObject Pizza1;

    public GameObject Self;

    public GameObject PizzaObject1;
    public GameObject PizzaObject2;
    public GameObject PizzaObject3;
    public GameObject PizzaObject4;
    public GameObject PizzaObject5;
    public GameObject PizzaObject6;

    public GameObject UpperCanvas;

    public GameObject ThrownPizza;

    public Sprite Pizzas1;
    public Sprite Pizza2;
    public Sprite Pizza3;
    public Sprite Pizza4;
    public Sprite Pizza5;
    public Sprite Pizza6;
    public Sprite Pizza7;
    public Sprite Pizza8;
    public Sprite Pizza9;
    public Sprite Pizza10;
    public Sprite Pizza11;
    bool alreadydone1 = false;
    bool alreadydone2 = false;
    bool alreadydone3 = false;
    bool alreadydone4 = false;
    bool alreadydone5 = false;
    bool alreadydone6 = false;

    public AudioSource music;
    public AudioSource Pickup;
    public AudioSource Throw;


    int HeldPizza;

    void Start()
    {
        image = GetComponent<Image>().sprite;
        StartBlinking();
        music.Play();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (HeldPizza > 0)
            {
                Throw.Play();
                GameObject childGameObject = Instantiate(ThrownPizza, gameObject.transform.position, Quaternion.identity, UpperCanvas.transform);
                childGameObject.transform.SetSiblingIndex(15);
                HeldPizza -= 1;
                CalculatePizza();

            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (!IsInvoking("MoveLeft"))
            {
                InvokeRepeating("MoveLeft", 0f, 0.15f);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            if (!IsInvoking("MoveLeft"))
            {
                InvokeRepeating("MoveLeft", 0f, 0.15f);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {

            CancelInvoke("MoveLeft");
        }
        else if (Input.GetKeyUp(KeyCode.Keypad4))
        {
            CancelInvoke("MoveLeft");
        }



        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!IsInvoking("MoveRight"))
            {
                InvokeRepeating("MoveRight", 0f, 0.15f);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            if (!IsInvoking("MoveRight"))
            {
                InvokeRepeating("MoveRight", 0f, 0.15f);
            }
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            CancelInvoke("MoveRight");
        }
        else if (Input.GetKeyUp(KeyCode.Keypad6))
        {
            CancelInvoke("MoveRight");
        }



        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!IsInvoking("MoveUp"))
            {
                InvokeRepeating("MoveUp", 0f, 0.15f);
            }
        }

        else if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            if (!IsInvoking("MoveUp"))
            {
                InvokeRepeating("MoveUp", 0f, 0.15f);
            }
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {

            CancelInvoke("MoveUp");
        }
        else if (Input.GetKeyUp(KeyCode.Keypad8))
        {

            CancelInvoke("MoveUp");
        }



        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (!IsInvoking("MoveDown"))
            {
                InvokeRepeating("MoveDown", 0f, 0.15f);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            if (!IsInvoking("MoveDown"))
            {
                InvokeRepeating("MoveDown", 0f, 0.15f);
            }
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            CancelInvoke("MoveDown");
        }
        else if (Input.GetKeyUp(KeyCode.Keypad2))
        {
            CancelInvoke("MoveDown");
        }


        if (alreadydone1 == false)
        {
            if (PizzaObject1.active == false)
            {
                StartCoroutine("PizzaRespawn1", PizzaObject1);
            }
        }
        if (alreadydone2 == false)
        {
            if (PizzaObject2.active == false)
            {
                StartCoroutine("PizzaRespawn2", PizzaObject2);
            }
        }
        if (alreadydone3 == false)
        {
            if (PizzaObject3.active == false)
            {
                StartCoroutine("PizzaRespawn3", PizzaObject3);
            }
        }
        if (alreadydone4 == false)
        {
            if (PizzaObject4.active == false)
            {
                StartCoroutine("PizzaRespawn4", PizzaObject4);
            }
        }
        if (alreadydone5 == false)
        {
            if (PizzaObject5.active == false)
            {
                StartCoroutine("PizzaRespawn5", PizzaObject5);
            }
        }
        if (alreadydone6 == false)
        {
            if (PizzaObject6.active == false)
            {
                StartCoroutine("PizzaRespawn6", PizzaObject6);
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
    public IEnumerator PizzaRespawn1(GameObject Pizza)
    {
        alreadydone1 = true;
        yield return new WaitForSeconds(2f);
        Pizza.SetActive(true);
        alreadydone1 = false;

    }
    public IEnumerator PizzaRespawn2(GameObject Pizza)
    {
        alreadydone2 = true;
        yield return new WaitForSeconds(2f);
        Pizza.SetActive(true);
        alreadydone2 = false;

    }
    public IEnumerator PizzaRespawn3(GameObject Pizza)
    {
        alreadydone3 = true;
        yield return new WaitForSeconds(2f);
        Pizza.SetActive(true);
        alreadydone3 = false;

    }
    public IEnumerator PizzaRespawn4(GameObject Pizza)
    {
        alreadydone4 = true;
        yield return new WaitForSeconds(2f);
        Pizza.SetActive(true);
        alreadydone4 = false;

    }
    public IEnumerator PizzaRespawn5(GameObject Pizza)
    {
        alreadydone5 = true;
        yield return new WaitForSeconds(2f);
        Pizza.SetActive(true);
        alreadydone5 = false;

    }
    public IEnumerator PizzaRespawn6(GameObject Pizza)
    {
        alreadydone6 = true;
        yield return new WaitForSeconds(2f);
        Pizza.SetActive(true);
        alreadydone6 = false;

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

            CalculatePizza();
            
        }

    }
    void CalculatePizza()
    {
        switch (HeldPizza)
        {
            case 0:
                Pizza1.SetActive(false);
                break;
            case 1:
                Pizza1.GetComponent<Image>().sprite = Pizzas1;
                break;
            case 2:
                Pizza1.GetComponent<Image>().sprite = Pizza2;
                break;
            case 3:
                Pizza1.GetComponent<Image>().sprite = Pizza3;
                break;
            case 4:
                Pizza1.GetComponent<Image>().sprite = Pizza4;
                break;
            case 5:
                Pizza1.GetComponent<Image>().sprite = Pizza5;
                break;
            case 6:
                Pizza1.GetComponent<Image>().sprite = Pizza6;
                break;
            case 7:
                Pizza1.GetComponent<Image>().sprite = Pizza7;
                break;
            case 8:
                Pizza1.GetComponent<Image>().sprite = Pizza8;
                break;
            case 9:
                Pizza1.GetComponent<Image>().sprite = Pizza9;
                break;
            case 10:
                Pizza1.GetComponent<Image>().sprite = Pizza10;
                break;
            case 11:
                Pizza1.GetComponent<Image>().sprite = Pizza11;
                break;




            default:
                break;
        }
        }


}