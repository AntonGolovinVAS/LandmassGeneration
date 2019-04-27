using UnityEngine;
using System.Collections;
using System;

public class MapDisplay : MonoBehaviour
{
    public Renderer textureRender;
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;

    public void DrawTexture(Texture2D texture2D)
    {
       
        textureRender.sharedMaterial.mainTexture = texture2D;
        textureRender.transform.localScale = new Vector3(texture2D.width, 1, texture2D.height);
    }

    public void DrawMesh(MeshData meshData, Texture2D texture2D)
    {
        meshFilter.sharedMesh = meshData.CreateMesh();
        meshRenderer.sharedMaterial.mainTexture = texture2D;
    }
}
