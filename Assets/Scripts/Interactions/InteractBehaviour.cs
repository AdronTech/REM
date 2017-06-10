using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBehaviour : IUsable
{
    public LineScript playerComment;
    public string triggerProgress = "";

    public override void Interaction()
    {
        Debug.Log("LookAt");
        FindObjectOfType<LineReader>().ReadLine(playerComment);
        if (triggerProgress != "")
        {
            FindObjectOfType<ProgressManager>().Trigger(triggerProgress);
        }
    }
}
