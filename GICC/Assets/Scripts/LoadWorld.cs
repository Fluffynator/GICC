using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LoadWorld : MonoBehaviour
{

    /*public enum DrawMode
    {
        NOISE_MAP,
        COLOR_MAP
    }

    public DrawMode drawMode;*/
    
    public int width;
    public int height;
    public int octaves;
    public int seed;
    public int moistSeed;

    public float persistance;
    public float lacunarity;
    public float scale;

    public Vector2 offset;

    public bool audoUpdate = true;

    public TerrainType[] bands;

    public void GenerateMap()
    {
        float[,] map = Noise.GenerateNoise(width, height, seed, scale, octaves, persistance, lacunarity, offset);

        float[,] moisture = Noise.GenerateNoise(width, height, moistSeed, scale, octaves, persistance, lacunarity, offset);

        Color[] color = new Color[width*height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float currentHeight = map[x, y];
                float currentMoist = moisture[x, y];

                color[y*width + x] = GetColor(currentHeight, currentMoist);
            }
        }

        MapDisplay display = FindObjectOfType<MapDisplay>();

        //if (drawMode == DrawMode.NOISE_MAP)
            display.DrawTexture(TextureGenerator.TextureFromNoise(map), TextureGenerator.TextureFromNoise(moisture), TextureGenerator.TextureFromColorMap(color, width, height));
       // else if (drawMode == DrawMode.COLOR_MAP)
       //     display.DrawTexture(TextureGenerator.TextureFromColorMap(color, width, height));
    }

    private Color GetColor(float currentHeight, float currentMoist)
    {
        if (currentHeight < 0.1) return bands[0].color;

        if (currentHeight > 0.8)
            return bands[6].color;

        if (currentHeight > 0.9)
            return bands[7].color;

        if (currentHeight > 0.6)
        {
            if (currentMoist < 0.33) return bands[5].color;
            return bands[4].color;
        }

        if (currentMoist < 0.16) return bands[3].color;
        if (currentMoist < 0.33) return bands[2].color;
        return bands[1].color;
    }
}

[System.Serializable]
public struct TerrainType
{
    public string name;
    public float height;
    public float moisture;
    public Color color;
}
