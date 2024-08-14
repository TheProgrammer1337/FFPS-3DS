using UnityEngine;

public class ThrownPizza : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Move", 0f, 0.1f);
    }
    void Move()
    {
        gameObject.transform.position += new Vector3(20, 0f, 0f);
        
        if (gameObject.transform.position.x > 400)
        {
            Destroy(gameObject);
        }
    }

}
