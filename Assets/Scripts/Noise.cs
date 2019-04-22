using UnityEngine;
using System.Collections;

public static class Noise
{
    public static float[,] generateNoiseMap(int _mapWidth, int _mapHeight, int _seed, float _scale, int _octaves, float _persistance, float _lacunarity, Vector2 _offSet)
    {
        float[,] noiseMap = new float[_mapWidth, _mapHeight];

        System.Random prng = new System.Random(_seed);
        Vector2[] octaveOffSets = new Vector2[_octaves];

        for (int i = 0; i < _octaves; i++)
        {
            float offSetX = prng.Next(-100000, 100000) + _offSet.x;
            float offSetY = prng.Next(-100000, 100000) + _offSet.y;
            octaveOffSets[i] = new Vector2(offSetX, offSetY);
        }

        #region If scale <= 0 return scale = 0
        if (_scale <= 0)
        {
            _scale = 0.0001f;
        }
        #endregion

        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;

        float halfWidth = _mapWidth / 2f;
        float halfHeight = _mapHeight / 2f;

        for (int y = 0; y < _mapHeight; y++)
        {
            for (int x = 0; x < _mapWidth; x++)
            {

                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;

                for (int i = 0; i < _octaves; i++)
                {
                    float sampleX = (x - halfWidth) / _scale * frequency + octaveOffSets[i].x;
                    float sampleY = (y - halfHeight) / _scale * frequency + octaveOffSets[i].y;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    noiseHeight += perlinValue * amplitude;

                    amplitude *= _persistance;
                    frequency *= _lacunarity;
                }

                if (noiseHeight > maxNoiseHeight)
                {
                    maxNoiseHeight = noiseHeight;
                }
                else if (noiseHeight < minNoiseHeight)
                {
                    minNoiseHeight = noiseHeight;
                }
                noiseMap[x, y] = noiseHeight;
            }
        }

        for (int y = 0; y < _mapHeight; y++)
        {
            for (int x = 0; x < _mapWidth; x++)
            {
                noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);
            }
        }
        return noiseMap;
    }
}

