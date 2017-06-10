using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBehaviour : IUsable
{
    [SerializeField]
    private LineScript _playerComment;
    [SerializeField]
    private string _triggerProgress = "";

    public LineScript playerComment
    {
        set { _playerComment = value; }
    }

    public string triggerProgress
    {
        set { _triggerProgress = value; }
    }

    public override void Interaction()
    {
        Debug.Log("LookAt");
        if(_playerComment) FindObjectOfType<LineReader>().ReadLine(_playerComment);
        if (_triggerProgress != "")
        {
            FindObjectOfType<ProgressManager>().Trigger(_triggerProgress);
        }
    }
}
