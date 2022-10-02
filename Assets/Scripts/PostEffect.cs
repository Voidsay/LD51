using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostEffect : MonoBehaviour
{
    private Material mat;

    void OnEnable()
    {
        mat = new Material(Shader.Find("Unlit/Colorpalet"));
    }

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src, dst, mat);
    }

    public void SetColorTheme(Texture texture)
    {
        mat.SetTexture("_ColorTheme", texture);
    }
}
