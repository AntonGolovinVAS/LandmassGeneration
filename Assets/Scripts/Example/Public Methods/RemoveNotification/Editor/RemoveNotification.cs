using UnityEditor;
using UnityEngine;

public class RemoveNotification : EditorWindow
{
    string str = "Прекратить показ уведомлений.Уведомление исчезает автоматически через некоторое время.Эта функция удалит его немедленно. ";

    string notification = "This is a notification";

    [MenuItem("Example/ Public Methods/ RemoveNotification")]
    static void Init()
    {
        GetWindow<RemoveNotification>("RemoveNotification");
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField(str, EditorStyles.helpBox);

        //notification = EditorGUILayout.TextField(notification);
        if (GUILayout.Button("Show Notification"))
        {
            this.ShowNotification(new GUIContent(notification));
        }

        if (GUILayout.Button("Remove Notification"))
        {
            this.RemoveNotification();
        }
    }
}
