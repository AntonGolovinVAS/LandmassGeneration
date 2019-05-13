using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EndWindows : EditorWindow
{

    string str = "Закрыть группу окон, начатую с EditorWindow.BeginWindows.";

    Rect windowRect = new Rect(10, 10, 110, 50);

    Vector2 scrollPos = Vector2.zero;

    [MenuItem("Example/ Public Methods/ EndWindows")]
    static void Init()
    {
        EndWindows window = (EndWindows)GetWindow(typeof(EndWindows));
        window.Show();
    }

    void OnGUI()
    {
        
        scrollPos = GUI.BeginScrollView(
            new Rect(0, 0, position.width, position.height), scrollPos, new Rect(0, 0, 1000, 1000)
            );

        EditorGUILayout.LabelField(str, EditorStyles.wordWrappedLabel);
        BeginWindows();
        windowRect = GUILayout.Window(1, windowRect, DoWindow, "HI HERE");
        EndWindows();
        GUI.EndScrollView();
    }

    void DoWindow(int windowID)
    {
        GUILayout.Button("HI");
        GUI.DragWindow();
    }
}
