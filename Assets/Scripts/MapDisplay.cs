using UnityEngine;
using System.Collections;

public class MapDisplay : MonoBehaviour
{
    public Renderer textureRender;

    public void DrawNoiseMap(float[,] _noiseMap)
    {
        int widht = _noiseMap.GetLength(0);
        int heigth = _noiseMap.GetLength(1);

        Texture2D texture2D = new Texture2D(widht, heigth);

        Color[] colorsMap = new Color[widht * heigth];
        for (int y = 0; y < heigth; y++)
        {
            for (int x = 0; x < widht; x++)
            {
                colorsMap[y * widht + x] = Color.Lerp(Color.black, Color.white, _noiseMap[x, y]);
            }
        }

        texture2D.SetPixels(colorsMap);
        texture2D.Apply();
        textureRender.sharedMaterial.mainTexture = texture2D;
        textureRender.transform.localScale = new Vector3(widht, 1, heigth);
    }
}
