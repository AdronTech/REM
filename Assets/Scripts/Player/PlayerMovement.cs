using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 1;
    public float collisionBoundsZ;
    public float collisionBoundsX;

    private SpriteRenderer spriterRenderer;

    void Start()
    {
        spriterRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void OnValidate()
    {
        Collider collider = GetComponent<Collider>();
        ((BoxCollider)collider).size = new Vector3(collisionBoundsX, 1, collisionBoundsZ);
    }

    // Update is called once per frame
    void Update () {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        input.Normalize();
        input *= speed*Time.deltaTime;

        RoomScript room = GetComponentInParent<RoomScript>();

	    if (input.x != 0)
	        spriterRenderer.flipX = input.x < 0;

        Vector3 new_pos = transform.localPosition + input;
        new_pos.z = Mathf.Max(collisionBoundsZ, Mathf.Min(new_pos.z, room.depth - collisionBoundsZ));
        new_pos.x = Mathf.Max(collisionBoundsX, Mathf.Min(new_pos.x, room.width - collisionBoundsX));
        transform.localPosition = new_pos;
    }
}
