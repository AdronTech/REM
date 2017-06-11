using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		InteractBehaviour i = gameObject.GetComponent<InteractBehaviour> ();
		i.Interaction ();
		Destroy (gameObject);
	}
}
