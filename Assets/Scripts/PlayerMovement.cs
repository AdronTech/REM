using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 1;
    public float collisionBounds;

    public SpriteRenderer spriterRenderer;

    void Start()
    {
        spriterRenderer = GetComponentInChildren<SpriteRenderer>();
    }

	// Update is called once per frame
	void Update () {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        input.Normalize();
        input *= speed*Time.deltaTime;

        Debug.Log(input);      

        RoomScript room = GetComponentInParent<RoomScript>();

	    if (input.x != 0)
	        spriterRenderer.flipX = input.x < 0;

        Vector3 new_pos = transform.localPosition + input;
        new_pos.z = Mathf.Max(0, Mathf.Min(new_pos.z, room.depth));
        new_pos.x = Mathf.Max(collisionBounds, Mathf.Min(new_pos.x, room.width - collisionBounds));
        transform.localPosition = new_pos;
    }
}
