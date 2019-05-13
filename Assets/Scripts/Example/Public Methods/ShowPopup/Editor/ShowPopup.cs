using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShowPopup : EditorWindow
{
    string str = "Всплывающие окно, только стилизация, без функциональности.";

    // Открытие окна с помощью этого метода не даст ему функциональность всплывающего окна, а только стилизацию.
    //Для полной функциональности всплывающих окон (например, автоматическое закрытие, когда окно теряет фокус), используйте PopupWindow .

    [MenuItem("Example/ Public Methods/ ShowPopup")]
    static void Init()
    {
        ShowPopup window = ScriptableObject.CreateInstance<ShowPopup>();
        window.position = new Rect(Screen.width / 2, Screen.height / 2, 250, 150);
        window.ShowPopup();
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField(str, EditorStyles.helpBox);

        EditorGUILayout.LabelField("This is an example of EditorWindow.ShowPopup", EditorStyles.wordWrappedLabel);
        GUILayout.Space(70);
        if (GUILayout.Button("Agree"))
        {
            this.Close();
        }
    }
}
