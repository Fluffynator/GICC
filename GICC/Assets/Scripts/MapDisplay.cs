using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{

    public Renderer texRender;

    public Renderer mTex;

    public Renderer cTex;

    public void DrawTexture(Texture2D noise, Texture2D moisture, Texture2D combined)
    {
        texRender.sharedMaterial.mainTexture = noise;
        texRender.transform.localScale = new Vector3(noise.width, 1, noise.height);

        mTex.sharedMaterial.mainTexture = moisture;
        mTex.transform.localScale = new Vector3(moisture.width, 1, moisture.height);

        cTex.sharedMaterial.mainTexture = combined;
        cTex.transform.localScale = new Vector3(combined.width, 1, combined.height);
    }

}
