using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 1;
    

	// Update is called once per frame
	void Update () {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        input.Normalize();
        input *= speed*Time.deltaTime;

        Debug.Log(input);      

        RoomScript room = GetComponentInParent<RoomScript>();

        Vector3 new_pos = transform.localPosition + input;
        new_pos.z = Mathf.Max(0, Mathf.Min(new_pos.z, room.depth));
        new_pos.x = Mathf.Max(0, Mathf.Min(new_pos.x, room.width));
        transform.localPosition = new_pos;
    }
}
