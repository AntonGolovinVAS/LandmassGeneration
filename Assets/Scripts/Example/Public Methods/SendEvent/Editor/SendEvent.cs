using UnityEditor;
using UnityEngine;

public class SendEvent : EditorWindow
{
    [MenuItem("Example/ Public Methods/ SendEvent")]
    static void Init()
    {
        GetWindow<SendEvent>(true, "Repaint");
    }
    private void OnGUI()
    {
        if (GUI.Button(new Rect(10f, 10f, 100f, 30f), "SendEvent"))
        {
            GetWindow<receiveEvent>().SendEvent(EditorGUIUtility.CommandEvent("Paste"));
        }
    }
}
