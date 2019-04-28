using UnityEngine;
using System.Collections;



public class MapGenerator : MonoBehaviour
{
    public enum DrawMode
    {
        NoiseMap,
        ColourMap,
        Mesh
    }

    public DrawMode drawMode;

    public const int MAP_CHUNK_SIZE = 241;
    [Range(0, 6)]
    public int levelOfDetail;

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

    [Tooltip("Управляет высотой меша.")]
    public float meshHeightMultiplier;
    public AnimationCurve meshHeightCurve;

    public bool autoUpdate;

    public TerrainType[] regions; 

    public void GenerateMap()
    {
        float[,] noiseMap = Noise.generateNoiseMap(MAP_CHUNK_SIZE, MAP_CHUNK_SIZE, seed, noiseScale, octaves, persistance, lacunarity, offSet);
       
        Color[] colourMap = new Color[MAP_CHUNK_SIZE * MAP_CHUNK_SIZE];
        for (int y = 0; y < MAP_CHUNK_SIZE; y++)
        {
            for (int x = 0; x < MAP_CHUNK_SIZE; x++)
            {
                float currentHeight = noiseMap[x, y];
                for (int i = 0; i < regions.Length; i++)
                {
                    if (currentHeight <= regions[i].height)
                    {
                        colourMap[y * MAP_CHUNK_SIZE + x] = regions[i].colour;
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
            display.DrawTexture(TextureGenerator.TextureFromColourMap(colourMap, MAP_CHUNK_SIZE, MAP_CHUNK_SIZE));
        }
        else if (drawMode == DrawMode.Mesh)
        {
            display.DrawMesh(MeshGenerator.GenerateTerrainMwsh(noiseMap, meshHeightMultiplier, meshHeightCurve, levelOfDetail), TextureGenerator.TextureFromColourMap(colourMap, MAP_CHUNK_SIZE, MAP_CHUNK_SIZE));
        }
        


    }

    private void OnValidate()
    {
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
