using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlainsTile : GICCTile
{
    public Sprite sprite;

    private void Awake()
    {
        tileType = TileTypes.PLAINS;
    }

}
