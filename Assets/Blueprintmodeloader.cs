using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Blueprintmodeloader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//GC.Collect();
		//Resources.UnloadUnusedAssets();
		SceneManager.LoadSceneAsync("Tycoon");
	}
	

}
