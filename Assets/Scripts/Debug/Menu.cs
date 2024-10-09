using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
	public GameObject childmenu;
	bool open;
	public float floaty;
	public Slider slider;
	public Text multipliertext;
	int newValuesaved = 1;
    // Use this for initialization
    void Start () {
		slider.value = PlayerPrefs.GetInt("ballpitmulti", 1);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
			childmenu.SetActive(!childmenu.active);
			open = !open;
			if (open)
			{
                Time.timeScale = 0.0f;
            }
            else
			{
                Time.timeScale = 1.0f;
				PlayerPrefs.SetInt("ballpitmulti", newValuesaved);
				PlayerPrefs.Save();
            }
        }
    }
	public void setballpitnum(float newValue)
	{
		multipliertext.text = newValue.ToString();
		newValuesaved = Mathf.FloorToInt(newValue);
	}
}
