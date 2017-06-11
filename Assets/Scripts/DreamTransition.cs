using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamTransition : MonoBehaviour
{

    private GameObject player;
    private CameraBehaviour main_camera;
    private TweenBehaviour tweenBehaviour;

	public RoomScript targetRoom;
	public Vector3 localPosition;

	void Start () {
        player = GameObject.Find("Player");
        main_camera = GameObject.Find("Main Camera").GetComponent<CameraBehaviour>();
	    tweenBehaviour = main_camera.GetComponent<TweenBehaviour>();
	}

	public void Transition()
	{
		StartCoroutine(TransitionCoroutine(targetRoom, localPosition));
	}

    IEnumerator TransitionCoroutine(RoomScript targetRoom, Vector3 localPosition)
    {
        foreach (Renderer renderer in targetRoom.GetComponentsInChildren<Renderer>())
            renderer.enabled = true;

        CameraBehaviour camera = GameObject.Find("Camera").GetComponent<CameraBehaviour>();
        camera.target = null;
        camera.transform.position = new Vector3(-9999999, -99999, -999999);

        RoomScript oldRoom = player.GetComponentInParent<RoomScript>();

        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<PlayerInteractions>().enabled = false;

        for (float i = 0.0f; i <= 1.0f; i += 0.01f)
        {
            main_camera.FOV += i * 2.5f;
            tweenBehaviour.SetAlpha(i);
            yield return null;
        }
        
        player.transform.SetParent(targetRoom.transform);
        player.transform.localPosition = localPosition;
        player.GetComponent<PlayerMovement>().Update();

        for (float i = 1.0f; i >= 0.0f; i -= 0.01f)
        {
            main_camera.FOV -= i * 2.5f;
            tweenBehaviour.SetAlpha(i);
            yield return null;
        }

        yield return null;

        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerInteractions>().enabled = true;


        if (oldRoom != targetRoom)
        {
            foreach (Renderer renderer in oldRoom.GetComponentsInChildren<Renderer>())
            renderer.enabled = false;
        }
    }
}
