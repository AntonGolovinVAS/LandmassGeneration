using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MainWindowMapGenerator : EditorWindow
{

    MapGenerator mapGenerator;


    private void Awake()
    {
        mapGenerator = FindObjectOfType<MapGenerator>();
    }


    [MenuItem("MapGenerator/ OpenMapGenerator")]
    public static void ShowWindow()
    { 
        GetWindowWithRect(typeof(MainWindowMapGenerator), new Rect(1000, 200, 300, 380), false, "Меню");
    }

    public void OnGUI()
    {
        if (GUILayout.Button("Generate height map"))
        {
            GetWindowWithRect(typeof(GenerateHeightMapEditorWindow), new Rect(1000, 200, 600, 600), false, "Генерация карты высот");
        }

        if (GUILayout.Button("Generate map"))
        {
            GetWindowWithRect(typeof(GenerateMapEditorWindow), new Rect(1000, 200, 600, 600), false, "Генерация 2D карты");
        }

        if (GUILayout.Button("Generate mesh map"))
        {
            GetWindowWithRect(typeof(GenerateMeshMapEditorWidow), new Rect(1000, 200, 600, 600), false, "Генерация меша карты");
        }
        GUILayout.Space(300);
        if (GUILayout.Button("Close"))
        {
            this.Close();
        }
    }
}
