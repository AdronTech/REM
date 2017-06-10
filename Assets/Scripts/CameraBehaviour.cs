using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraBehaviour : MonoBehaviour {

    [Range(0, 20)]
    public float height;
    [Range(0, 180)]
    public float FOV;

    public float ZOffset;

    public GameObject target;

    // Use this for initialization
    void OnValidate () {
        move();
	}
	
	// Update is called once per frame
	void Update () {
        move();
	}

    public void move()
    {
        if (!target)
            return;

        RoomScript room = target.GetComponentInParent<RoomScript>();
        Camera cam = GetComponent<Camera>();

        float realHeigth = Mathf.Min(height, room.height);

        cam.fieldOfView = FOV;
        Vector3 offset = new Vector3(0, realHeigth / 2f, -realHeigth / (2f * Mathf.Tan(Mathf.Deg2Rad * cam.fieldOfView / 2f)) + ZOffset);

        float boundOffset = offset.y * cam.aspect;
        float boundL = room.transform.position.x + boundOffset, boundR = room.transform.position.x + room.width - boundOffset; // set propper values
        transform.position = new Vector3(Mathf.Max(boundL, Mathf.Min(target.transform.position.x, boundR)), target.transform.position.y, room.transform.position.z) + offset;
    }
   
}
