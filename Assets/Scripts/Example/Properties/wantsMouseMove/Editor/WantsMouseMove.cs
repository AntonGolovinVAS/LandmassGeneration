using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WantsMouseMove : EditorWindow
{
    string str = "Проверяет, получены ли события MouseMove в графическом интерфейсе в этом окне редактора." +
        " Если установлено значение true, окно получает вызов OnGUI всякий раз, когда мышь перемещается над окном. ";

    [MenuItem("Example/ Properties/ WantsMouseMove")]
    static void Init()
    {
        var editorWindow = GetWindowWithRect(typeof(WantsMouseMove), new Rect(0, 0, 300, 100));
        editorWindow.Show();
    }

    void OnGUI()
    {
        GUILayout.TextArea(str);
        wantsMouseMove = EditorGUILayout.Toggle("Receive Movement: ", wantsMouseMove);
        EditorGUILayout.LabelField("Mouse Position: ", Event.current.mousePosition.ToString());
        if (Event.current.type == EventType.MouseMove)
        {
            Repaint();
        }
    }
}
