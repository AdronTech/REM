using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class DoorBehaviour : IUsable
{
    [SerializeField]
    private bool _locked = false;
    public bool locked
    {
        set { _locked = value; }
    }
    public LineScript lockedComment;
    public DoorBehaviour linkedDoor;
    public bool autoLinkBack;
    public bool frontDoor;

    private TweenBehaviour tweenBehaviour;
    private GameObject main_camera;
    private GameObject camera;

    public void Start()
    {
        base.Start();

        main_camera = GameObject.Find("Main Camera");
        camera = GameObject.Find("Camera");
        tweenBehaviour = main_camera.GetComponent<TweenBehaviour>();
    }


    public override void Interaction()
    {
        if (_locked)
        {
            if(lockedComment) FindObjectOfType<LineReader>().ReadLine(lockedComment);
        }
        else UseDoor();
    }

    private void UseDoor()
    {
        if (!linkedDoor)
            return;

        if (autoLinkBack)
            linkedDoor.linkedDoor = this;

        RoomScript otherRoom = linkedDoor.GetComponentInParent<RoomScript>();
        player.transform.SetParent(otherRoom.transform);

        player.transform.localPosition = linkedDoor.transform.localPosition;
        player.GetComponent<PlayerMovement>().Update();

        if (frontDoor)
            StartCoroutine(Tweening(this, linkedDoor));
        else
            StartCoroutine(Tweening(linkedDoor, this));


    }

    IEnumerator Tweening(DoorBehaviour front, DoorBehaviour back)
    {
        camera.GetComponent<CameraBehaviour>().target = back.gameObject;
        main_camera.GetComponent<CameraBehaviour>().target = front.gameObject;

        RoomScript frontRoom = front.GetComponentInParent<RoomScript>();

        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<PlayerInteractions>().enabled = false;

        float alpha = 0.0f;
        float offset = 0.0f;

        for (float i = 0.0f; i <= 1.0f; i += 0.025f)
        {
            alpha = i;

            if (!frontDoor)
                alpha = 1 - i;

            offset = alpha * frontRoom.depth;

            main_camera.GetComponent<CameraBehaviour>().ZOffset = offset;
            camera.GetComponent<CameraBehaviour>().ZOffset = offset - frontRoom.depth;

            tweenBehaviour.SetAlpha(alpha);

            yield return null;
        }

        main_camera.GetComponent<CameraBehaviour>().target = player;
        main_camera.GetComponent<CameraBehaviour>().ZOffset = 0.0f;

        yield return null;
        tweenBehaviour.SetAlpha(0.0f);

        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerInteractions>().enabled = true;
    }
}
