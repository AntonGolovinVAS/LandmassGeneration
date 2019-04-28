using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MainWindowMapGenerator : EditorWindow
{
    TerrainType[] regions;

    private void Awake()
    {
        regions = FindObjectOfType<MapGenerator>().regions;
    }


    [MenuItem("MapGenerator/ OpenMapGenerator")]
    public static void ShowWindow()
    {
        GetWindow<MainWindowMapGenerator>("Welcome to map generator");
    }

    public void OnGUI()
    {
        
        if (GUILayout.Button("Open Map Generator"))
        {
            GetWindow<WindowMapGenerator>("MapGenerator");
            
        }
        

    }
    void OpenColorRegions()
    {
        for (int i = 0; i < regions.Length; i++)
        {
            regions[i].colour = EditorGUILayout.ColorField(regions[i].name, regions[i].colour);
        }
    }
}
