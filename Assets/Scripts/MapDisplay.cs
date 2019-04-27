using UnityEngine;
using System.Collections;

public class MapDisplay : MonoBehaviour
{
    public Renderer textureRender;

    public void DrawTexture(Texture2D texture2D)
    {
       
        textureRender.sharedMaterial.mainTexture = texture2D;
        textureRender.transform.localScale = new Vector3(texture2D.width, 1, texture2D.height);
    }
}
