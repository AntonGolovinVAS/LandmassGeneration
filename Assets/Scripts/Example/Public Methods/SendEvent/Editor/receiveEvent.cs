using UnityEditor;
using UnityEngine;

public class receiveEvent : EditorWindow
{
    [MenuItem("Example/ Public Methods/ receiveEvent")]
    static void Init()
    {
            GetWindow<receiveEvent>(true, "Receive Event Window");
    }

    void OnGUI()
    {
        Event e = Event.current;

        if (e.commandName == "Paste")
            Debug.Log("Paste received");
    }
}
