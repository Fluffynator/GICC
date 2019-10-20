using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LoadWorld : MonoBehaviour
{

    public enum DrawMode
    {
        NOISE_MAP,
        COLOR_MAP
    }

    public DrawMode drawMode;
    
    public int width;
    public int height;
    public int octaves;
    public int seed;

    public float persistance;
    public float lacunarity;
    public float scale;

    public Vector2 offset;

    public bool audoUpdate = true;

    public TerrainType[] bands;

    public void GenerateMap()
    {
        float[,] map = Noise.GenerateNoise(width, height, seed, scale, octaves, persistance, lacunarity, offset);

        Color[] color = new Color[width*height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float currentHeight = map[x, y];
                for (int i = 0; i < bands.Length; i++)
                {
                    if (currentHeight <= bands[i].height)
                    {
                        color[y * width + x] = bands[i].color;
                        break;
                    }
                }
            }
        }

        MapDisplay display = FindObjectOfType<MapDisplay>();

        if (drawMode == DrawMode.NOISE_MAP)
            display.DrawTexture(TextureGenerator.TextureFromNoise(map));
        else if (drawMode == DrawMode.COLOR_MAP)
            display.DrawTexture(TextureGenerator.TextureFromColorMap(color, width, height));
    }
    
    /*LandGen gen;

    Texture2D world;

    public Tilemap map;

    public TileBase[] tile;

    bool generate = false;

    void Start()
    {
        gen = new LandGen();
        world = gen.GeneratePerlin(0);
    }
    
    void Update()
    {
        if(generate)
        {
            Debug.Log("Started");
            map.ClearAllTiles();

            for (int x = 0; x < 256; x++)
            {
                for(int y = 0; y < 256; y++)
                {
                    map.SetTile(new Vector3Int(x, y, 0), DecideTile(world.GetPixel(x,y)));
                }
            }

            generate = false;
            Debug.Log("Finished");
        }
    }

    public void GeneratePressed()
    {
        generate = true;
    }

    //GICCTile DecideTile(Color col)
    TileBase DecideTile(Color col)
    {
        if (col.r > 0.5f)
            return tile[0];
        else
            return tile[1];
    }*/

}

[System.Serializable]
public struct TerrainType
{
    public string name;
    public float height;
    public Color color;
}
