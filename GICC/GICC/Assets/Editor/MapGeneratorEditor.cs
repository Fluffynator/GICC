using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LoadWorld))]
public class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        LoadWorld genMap = (LoadWorld)target;

        if(DrawDefaultInspector())
        {
            if(genMap.audoUpdate)
            {
                genMap.GenerateMap();
            }
        }

        if(GUILayout.Button("Generate Map"))
        {
            genMap.GenerateMap();
        }
    }

}
