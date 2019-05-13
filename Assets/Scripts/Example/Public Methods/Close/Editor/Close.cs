using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Close : EditorWindow
{

    string str = "Закройте окно редактора. Это разрушит окно редактора.";

    [MenuItem("Example/ Public Methods/ Close")]
    static void Init()
    {
        Close window = (Close)GetWindowWithRect(typeof(Close), new Rect(0, 0, 200, 100));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.TextArea(str);
        EditorGUILayout.LabelField("EditorWindow.Close example", EditorStyles.wordWrappedLabel);

        if (GUILayout.Button("Close!"))
            this.Close();
    }
}
