using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineReader : MonoBehaviour {

    public void ReadLine(LineScript ls)
    {
        if (ls)
        {
            if (reader != null)
            {
                StopCoroutine(reader);
            }
            reader = StartCoroutine(read(ls));
        }
    }
    private Coroutine reader;
    private PlayerMovement movement;
    private AudioSource audio;
    private Canvas canvas;
    private Text bubble;
    private RectTransform rectTransform;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        bubble = GetComponentInChildren<Text>();
        canvas = GetComponent<Canvas>();
        movement = FindObjectOfType<PlayerMovement>();
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        RoomScript room = movement.GetComponentInParent<RoomScript>();

        float width = rectTransform.rect.width * rectTransform.localScale.x;

        float z = 0;
        if (movement.transform.localPosition.z < 0.5)
            z = 0.5f - movement.transform.localPosition.z;

        if (movement.transform.localPosition.x < width /2f)
            rectTransform.localPosition = new Vector3(width / 2f - movement.transform.localPosition.x, rectTransform.localPosition.y, z);
        else if (room.width - movement.transform.localPosition.x < width / 2f)
            rectTransform.localPosition = new Vector3(-width / 2f + room.width - movement.transform.localPosition.x, rectTransform.localPosition.y, z);
        else
            rectTransform.localPosition = new Vector3(0, rectTransform.localPosition.y, z);

    }

    private IEnumerator read(LineScript ls)
    {
        canvas.enabled = true;
        movement.enabled = false;
		float waittime = (ls.time == 0f)?2f:ls.time;
        bubble.text = ls.line;

        if (ls.clip)
        {
            waittime = ls.clip.length;
            audio.clip = ls.clip;
            audio.Play();
        }
        yield return new WaitForSeconds(waittime);
        canvas.enabled = false;
        reader = null;
        movement.enabled = true;
    }
}
