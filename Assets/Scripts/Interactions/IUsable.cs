using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IUsable : MonoBehaviour
{
    protected GameObject player;

    public void Start()
    {
        player = GameObject.Find("Player");
    }
    
    public abstract void Interaction();
}