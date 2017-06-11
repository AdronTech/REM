using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TweenBehaviour : MonoBehaviour {

    public bool activeShader;
    public Material mat;

    [Range(0.0f, 1.0f)]
    public float alpha;

    public void Awake()
    {
        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 32, RenderTextureFormat.ARGB32);

        mat = new Material(Shader.Find("Custom/TweenShader"));
        mat.SetTexture("_OtherTex", renderTexture);
        mat.SetFloat("_alpha", 0.0f);

        GameObject.Find("Camera").GetComponent<Camera>().targetTexture = renderTexture;
    }

//    public void OnValidate()
//    {
//        SetAlpha(alpha);
//    }

    public void SetAlpha(float _alpha)
    {
        mat.SetFloat("_alpha", _alpha);
    }

    public void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (activeShader)
            Graphics.Blit(src, dest, mat);
        else
        {
            Graphics.Blit(src, dest);
        }
    }
}
