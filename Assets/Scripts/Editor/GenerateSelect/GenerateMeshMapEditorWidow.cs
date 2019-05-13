using UnityEditor;
using UnityEngine;

public class GenerateMeshMapEditorWidow : EditorWindow
{
    MapGenerator mapGenerator;


    private void Awake()
    {
        mapGenerator = FindObjectOfType<MapGenerator>();
    }

    private void OnGUI()
    {
        //GetWindow<GenerateMeshMapEditorWidow>("Генерация меша карты");
    }
}
