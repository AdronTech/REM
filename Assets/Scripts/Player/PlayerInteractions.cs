using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private IUsable interaction_target;
    
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Interact"))
        {
            if(interaction_target)
                interaction_target.Interaction();
	    }
	}

    void OnTriggerEnter(Collider other)
    {
        interaction_target = other.GetComponent<IUsable>();
    }

    void OnTriggerExit(Collider other) {
        IUsable i = other.GetComponent<IUsable>();
        if (i == interaction_target) interaction_target = null;
    }
}
