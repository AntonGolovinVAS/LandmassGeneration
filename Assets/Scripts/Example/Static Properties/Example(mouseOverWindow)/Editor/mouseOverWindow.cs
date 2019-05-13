using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class mouseOverWindow : EditorWindow
{
    string str = "Окно EditorWindow в данный момент находится под курсором мыши. "; 

    string mouseOver = "Nothing...";

    [MenuItem("Example/ Static Properties/ MouseOverWindow")]
    static void Init()
    {
        GetWindow<mouseOverWindow>("mouseOver");
    }

    void OnGUI()
    {
        GUILayout.TextArea(str);
        GUILayout.Label("Mouse over:\n" + mouseOver);
        if (GUILayout.Button("Close"))
        {
            this.Close();
        }
        mouseOver = EditorWindow.mouseOverWindow ? EditorWindow.mouseOverWindow.ToString() : "Nothing...";
    }

    private void OnInspectorUpdate()
    {
        if (EditorWindow.mouseOverWindow)
        {
            EditorWindow.mouseOverWindow.Focus();
        }
        this.Repaint();
    }
}
