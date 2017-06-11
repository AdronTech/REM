using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other)
	{
		InteractBehaviour i = gameObject.GetComponent<InteractBehaviour> ();
		i.Interaction();



		Destroy (gameObject);
	}

	IEnumerator BlendOut()
	{
		CameraBehaviour camera = GameObject.Find ("Camera").GetComponent<CameraBehaviour>();
		camera.target = null;
		camera.transform.position = new Vector3 (-999999, -99999, -99999);

		TweenBehaviour tween = GameObject.Find ("Main Camera").GetComponent<TweenBehaviour> ();

		for (float i = 0.0f; i <= 1.0f; i += 0.01f) {
			tween.SetAlpha (i);
			yield return null; 	 	
		} 	

		SceneManager.LoadScene ("GameOver");

	}
}
