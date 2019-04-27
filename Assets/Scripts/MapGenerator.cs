using UnityEngine;
using System.Collections;



public class MapGenerator : MonoBehaviour
{
    public enum DrawMode
    {
        NoiseMap,
        ColourMap
    }

    public DrawMode drawMode;

    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    public int octaves;

    [Tooltip("Изменение persistance управляет тем, как сильно детали влияют на общую форму карты.")]
    [Range(0, 1)]
    public float persistance; // Можем влиять как сильно уменьшается амплитуда  каждой последующей октавы. 


    [Tooltip("Увеличение lacunarity увеличивает количество маленьких деталей.")]
    /// <summary>
    /// Мера неоднородности.
    /// </summary>
    public float lacunarity; 

    public int seed;
    public Vector2 offSet;

    public bool autoUpdate;

    public TerrainType[] regions; 

    public void GenerateMap()
    {
        float[,] noiseMap = Noise.generateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offSet);
       
        Color[] colourMap = new Color[mapWidth * mapHeight];
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float currentHeight = noiseMap[x, y];
                for (int i = 0; i < regions.Length; i++)
                {
                    if (currentHeight <= regions[i].height)
                    {
                        colourMap[y * mapWidth + x] = regions[i].colour;
                        break;
                    }
                }
            }
        }
        MapDisplay display = FindObjectOfType<MapDisplay>();
        if (drawMode == DrawMode.NoiseMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap));
        }
        else if (drawMode == DrawMode.ColourMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromColourMap(colourMap, mapWidth, mapHeight));
        }
        


    }

    private void OnValidate()
    {
        if (mapWidth < 1)
        {
            mapWidth = 1;
        }
        if (mapHeight < 1)
        {
            mapHeight = 1;
        }
        if (lacunarity < 1)
        {
            lacunarity = 1;
        }
        if (octaves < 1)
        {
            octaves = 1;
        }
    }

}

[System.Serializable]
public struct TerrainType
{
    public string name;
    public float height;
    public Color colour;
}
