using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Position : EditorWindow
{
    string str = "Желаемая позиция окна в пространстве экрана. Установка этого значения приведет к отстыковке окна, если оно пристыковано. ";
    Vector2Int p1;
    bool showBtn = true;
    EditorWindow editorWindow; 

    [MenuItem("Example/ Properties/ Position")]
    static void Init()
    {
        GetWindow<Position>("Позиция");
        var editorWindow = EditorWindow.GetWindow<Position>();
    }

    void OnGUI()
    {
        GUILayout.TextArea(str);
        //editorWindow.titleContent.text = str;
        Rect r = position;
        GUILayout.Label("Position: " + r.x + "x" + r.y);

        p1 = EditorGUILayout.Vector2IntField("Set the position: " , p1);
        if (showBtn)
        {
            if (GUILayout.Button("Задать новую позицию"))
            {
                r.x = p1.x;
                r.y = p1.y;

                position = r;
            }
        }
    }

}
