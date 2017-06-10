using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    private Transform player;

    [Range(0, 20)]
    public float camOffset;
    [Range(0, 180)]
    public float FOV;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

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
        RoomScript room = player.GetComponentInParent<RoomScript>();
        Camera cam = GetComponent<Camera>();
        cam.fieldOfView = FOV;
        Vector3 offset = new Vector3(0, Mathf.Sin(Mathf.Deg2Rad * cam.fieldOfView / 2f) * camOffset, -Mathf.Cos(Mathf.Deg2Rad * cam.fieldOfView / 2f) * camOffset);

        float boundOffset = offset.y * cam.aspect;
        float boundL = room.transform.position.x + boundOffset, boundR = room.transform.position.x + room.width - boundOffset; // set propper values
        transform.position = new Vector3(Mathf.Max(boundL, Mathf.Min(player.position.x, boundR)), player.position.y, room.transform.position.z) + offset;
    }
}
