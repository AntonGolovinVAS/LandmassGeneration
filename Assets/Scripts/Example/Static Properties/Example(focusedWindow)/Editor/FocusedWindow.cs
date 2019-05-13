using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FocusedWindow : EditorWindow
{
    string str = "Окно EditorWindow, которое в настоящее время имеет фокус клавиатуры.";

    [MenuItem("Example/ Static Properties/ FocusedWindow")]
    public static void Init()
    {
        GetWindow<FocusedWindow>();
    }

    void OnGUI()
    {
        GUILayout.TextArea(str);
        GUILayout.Label(EditorWindow.focusedWindow.ToString());
    }

}
