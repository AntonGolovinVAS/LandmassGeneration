using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour
{
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

    public void GenerateMap()
    {
        float[,] noiseMap = Noise.generateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offSet);
        MapDisplay display = FindObjectOfType<MapDisplay>();
        display.DrawNoiseMap(noiseMap);
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
