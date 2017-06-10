using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private IInteractable interaction_target;
    
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Interact"))
        {
            if(interaction_target)
                interaction_target.interact();
	    }
	}

    void OnTriggerEnter(Collider other)
    {
        interaction_target = other.GetComponent<IInteractable>();
    }

    void OnTriggerExit(Collider other) {
        IInteractable i = other.GetComponent<IInteractable>();
        if (i == interaction_target) interaction_target = null;
    }
}
