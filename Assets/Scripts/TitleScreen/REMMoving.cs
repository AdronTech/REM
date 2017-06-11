using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REMMoving : MonoBehaviour {

	void Update () {
		
        transform.localScale = new Vector3(2 + Mathf.Sin(Time.time) * 0.25f, 2 + Mathf.Cos(Time.time) * 0.25f, 1);
	}
}
