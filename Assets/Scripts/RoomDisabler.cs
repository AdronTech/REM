using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDisabler : MonoBehaviour {

	void Start () {

	    foreach (RoomScript room in GameObject.FindObjectsOfType<RoomScript>())
	    {
	        if (!room.GetComponentInChildren<PlayerMovement>())
	        {
	            foreach (Renderer renderer in room.GetComponentsInChildren<Renderer>())
	                renderer.enabled = false;
	        }
	    }
	}
}
