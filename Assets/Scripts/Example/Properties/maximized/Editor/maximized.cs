using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class maximized : EditorWindow
{
    string str = "Размер окна увеличивается так же, как и в Unity.";
    //Установка развернутого сделает Unity Editor таким же большим, как экран Unity. Если окно разблокировано, это значение всегда будет ложным,
    //и установка его не будет иметь никакого эффекта. Это обрабатывается опцией GUILayout.Toggle .

    [MenuItem("Example/ Properties/  maximized")]
    public static void Init()
    {
        GetWindow<maximized>("Развернуто");
    }

    void OnGUI()
    {
        GUILayout.TextArea(str);
        maximized = GUILayout.Toggle(maximized, "Развернуть окно");
    }
}
