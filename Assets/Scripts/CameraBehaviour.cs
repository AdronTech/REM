using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    private GameObject player;

    [Range(0, 20)]
    public float height;
    [Range(0, 180)]
    public float FOV;

    public void Start()
    {
        player = GameObject.Find("Player");
    }

    // Use this for initialization
    void OnValidate () {
        player = GameObject.Find("Player");
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

        float realHeigth = Mathf.Min(height, room.height);

        cam.fieldOfView = FOV;
        Vector3 offset = new Vector3(0, realHeigth / 2f, -realHeigth / (2f * Mathf.Tan(Mathf.Deg2Rad * cam.fieldOfView / 2f)));

        float boundOffset = offset.y * cam.aspect;
        float boundL = room.transform.position.x + boundOffset, boundR = room.transform.position.x + room.width - boundOffset; // set propper values
        transform.position = new Vector3(Mathf.Max(boundL, Mathf.Min(player.transform.position.x, boundR)), player.transform.position.y, room.transform.position.z) + offset;
    }
}
