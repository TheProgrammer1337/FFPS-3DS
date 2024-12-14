using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Toppingswitch : MonoBehaviour {


	public void onClicked(GameObject toppingObject)
	{
		toppingObject.SetActive(!toppingObject.active);
	}
    public void onClicked2(GameObject buttonObject)
	{
        if (buttonObject.GetComponent<Image>().color.a == 1)
		{
            buttonObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
		else
		{
            buttonObject.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
        }
    }
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			SceneManager.LoadScene("8BitMainMenu");
		}
	}
}
