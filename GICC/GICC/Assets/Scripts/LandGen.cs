using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandGen
{

    public int width = 256;
    public int height = 256;

    public float scale = 20f;

    public Texture2D GeneratePerlin(ulong seed)
    {
        //int xOffset = (int)((seed << 8) >> 8);
        //int yOffset = (int)(seed >> 8);

        Texture2D tex = new Texture2D(width, height);

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                Color color = GetColor(x, y);
                tex.SetPixel(x, y, color);
            }
        }

        // Update the texture
        tex.Apply();
        return tex;
    }

    private Color GetColor(int x, int y)
    {
        float xCoord = (float)x / width * scale;
        float yCoord = (float)y / height * scale;

        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }
}
