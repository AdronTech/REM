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
    [SerializeField]
    private AudioClip _sound;

    public LineScript playerComment
    {
        set { _playerComment = value; }
    }

    public string triggerProgress
    {
        set { _triggerProgress = value; }
    }

    public AudioClip sound
    {
        set { _sound = value; }
    }

    public override void Interaction()
    {
        if (_sound) FindObjectOfType<InteractionSoundPlayer>().PlaySound(_sound);
        if(_playerComment) FindObjectOfType<LineReader>().ReadLine(_playerComment);
        if (_triggerProgress != "")
        {
            FindObjectOfType<ProgressManager>().Trigger(_triggerProgress);
        }
    }
}
