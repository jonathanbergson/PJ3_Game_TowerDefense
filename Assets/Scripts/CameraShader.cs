using System;
using UnityEngine;

public class CameraShader : MonoBehaviour
{
    public static CameraShader instance;
    public Material mat;

    void Awake()
    {
        instance = this;
        Debug.Log("CameraShader Awake");
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, mat);
    }

    public void SetLero(float value)
    {
        mat.SetFloat("_lero", value);
    }
}
