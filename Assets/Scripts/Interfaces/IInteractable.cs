using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IInteractable : MonoBehaviour
{
    protected GameObject player;

    public void Start()
    {
        player = GameObject.Find("Player");
    }

    public abstract void interact();
}