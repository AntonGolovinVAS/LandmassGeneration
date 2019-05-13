using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Focus1 : EditorWindow
{
    
    //Фокус публичный метод управления , который активно окно для использования клавиатуры.
    //В приведенных ниже примерах активная клавиатура EditorWindow заменяется другой клавиатурой EditorWindow.
    string str = "Перемещает фокус клавиатуры в другое окно EditorWindow.";

    public static Focus1 Instance = null;
    public Focus1()
    {
        Instance = this;
    }

    [MenuItem("Example/ Public Methods/ Focus1")]
    static void Init()
    {
        GetWindow<Focus1>("Focus_1");
    }

   

    void OnGUI()
    {
        EditorGUILayout.LabelField(str, EditorStyles.helpBox);
        if (GUILayout.Button("Okno focusa 2"))
        {
            Focus2.Instance.Focus();
        }    
    }
}
