using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{

    public Renderer texRender;

    public void DrawTexture(Texture2D tex)
    {
        texRender.sharedMaterial.mainTexture = tex;
        texRender.transform.localScale = new Vector3(tex.width, 1, tex.height);
    }

}
