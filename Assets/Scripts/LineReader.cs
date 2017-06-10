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

    private AudioSource audio;
    private Canvas canvas;
    private Text bubble;
    private PlayerMovement movement;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        bubble = GetComponentInChildren<Text>();
        canvas = GetComponent<Canvas>();
        movement = FindObjectOfType<PlayerMovement>();
    }

    private IEnumerator read(LineScript ls)
    {
        canvas.enabled = true;
        movement.enabled = false;
        float waittime = 2f;
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
