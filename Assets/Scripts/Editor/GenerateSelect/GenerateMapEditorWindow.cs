using UnityEditor;
using UnityEngine;

public class GenerateMapEditorWindow : EditorWindow
{
    MapGenerator mapGenerator;


    private void Awake()
    {
        mapGenerator = FindObjectOfType<MapGenerator>();
    }

    private void OnGUI()
    {
        //GetWindow<GenerateMeshMapEditorWidow>("Генерация 2D карты");
    }
}
