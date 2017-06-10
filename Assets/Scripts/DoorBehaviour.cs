using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : IInteractable
{
    public DoorBehaviour linkedDoor;
    public bool autoLinkBack;

    public override void interact()
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
