using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeyPressed : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKeyDown)
            SceneManager.LoadScene("Manor");
	}
}
