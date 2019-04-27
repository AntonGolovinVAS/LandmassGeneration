using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextureGenerator
{
    public static Texture2D TextureFromColourMap(Color[] colourMap, int width, int height)
    {
        Texture2D texture2D = new Texture2D(width, height);

        //Делаем карту "кубической".
        texture2D.filterMode = FilterMode.Point;
        texture2D.wrapMode = TextureWrapMode.Clamp;

        texture2D.SetPixels(colourMap);
        texture2D.Apply();
        return texture2D;
    }
    public static Texture2D TextureFromHeightMap(float[,] _heightMap)
    {
        int width = _heightMap.GetLength(0);
        int heigth = _heightMap.GetLength(1);

        Color[] colorsMap = new Color[width * heigth];
        for (int y = 0; y < heigth; y++)
        {
            for (int x = 0; x < width; x++)
            {
                colorsMap[y * width + x] = Color.Lerp(Color.black, Color.white, _heightMap[x, y]);
            }
        }


        return TextureFromColourMap(colorsMap, width, heigth);
    }
}
