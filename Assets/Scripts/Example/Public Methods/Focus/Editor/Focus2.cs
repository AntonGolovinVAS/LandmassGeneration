using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Focus2 : EditorWindow
{
    public static Focus2 Instance = null;

    [MenuItem("Example/ Public Methods/ Focus2")]
    static void Init()
    {
        GetWindow<Focus2>("Focus2");
    }

    public Focus2()
    {
        Instance = this;
    }

    void OnGUI()
    {
        if (GUILayout.Button("Okno focusa 1"))
        {
           Focus1.Instance.Focus();
        }
    }
}
