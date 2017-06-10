using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public Transform target;

    [Range(0, 20)]
    public float camOffset;
    [Range(0, 180)]
    public float FOV;

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
        RoomScript room = target.GetComponentInParent<RoomScript>();
        Camera cam = GetComponent<Camera>();
        cam.fieldOfView = FOV;
        Vector3 offset = new Vector3(0, Mathf.Sin(Mathf.Deg2Rad * cam.fieldOfView / 2f) * camOffset, -Mathf.Cos(Mathf.Deg2Rad * cam.fieldOfView / 2f) * camOffset);

        float boundOffset = offset.y * cam.aspect;
        float boundL = room.transform.position.x + boundOffset, boundR = room.transform.position.x + room.width - boundOffset; // set propper values
        transform.position = new Vector3(Mathf.Max(boundL, Mathf.Min(target.position.x, boundR)), target.position.y, room.transform.position.z) + offset;
    }
}
