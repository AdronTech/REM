using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 0.75f;
    public float collisionBoundsZ;
    public float collisionBoundsX;

    private SpriteRenderer spriterRenderer;
    private Animator animator;

    void Start()
    {
        spriterRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    void OnValidate()
    {
        Collider collider = GetComponent<Collider>();
        ((BoxCollider) collider).size = new Vector3(collisionBoundsX, 1, collisionBoundsZ);
    }

    // Update is called once per frame
    public void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        animator.SetBool("Moving", input.sqrMagnitude > 0);
        input.Normalize();
        input *= speed * Time.deltaTime;

        RoomScript room = GetComponentInParent<RoomScript>();

        if (input.x != 0)
            spriterRenderer.flipX = input.x < 0;

        Vector3 new_pos = transform.localPosition + input;
        new_pos.z = Mathf.Max(collisionBoundsZ, Mathf.Min(new_pos.z, room.depth - collisionBoundsZ));
        new_pos.x = Mathf.Max(collisionBoundsX, Mathf.Min(new_pos.x, room.width - collisionBoundsX));

        if (room.heights != null)
            new_pos.y = room.heights.Evaluate(new_pos.x);

        transform.localPosition = new_pos;

//        if (Input.GetKeyDown("space"))
//        {
//            GetComponent<DreamTransition>()
//                .Transition(GameObject.Find("Library").GetComponent<RoomScript>(), new Vector3(2.5f, 0, 1f));
//        }
    }

}