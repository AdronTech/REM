using System.Collections;
using System.Collections.Generic;
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


    public override void Interaction()
    {
        if (_locked)
        {
            FindObjectOfType<LineReader>().ReadLine(lockedComment);
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
    }
}
