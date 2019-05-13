
using UnityEditor;
using UnityEngine;

public class RandomizeInSelection : EditorWindow
{
    public float rotationAmount = 0.33f;
    public string selected = "";

    [MenuItem("Example/ Public Methods/ RandomizeInSelection")]
    static void RandomizeWindow()
    {
        RandomizeInSelection window = ScriptableObject.CreateInstance(typeof(RandomizeInSelection)) as RandomizeInSelection;
        window.ShowUtility();
    }

    void RandomizeSelected()
    {
        foreach (var transform in Selection.transforms)
        {
            Quaternion rotation = Random.rotation;
            transform.localRotation = Quaternion.Slerp(transform.localRotation, rotation, rotationAmount);
        }
    }

    void OnGUI()
    {
        foreach (var t in Selection.transforms)
        {
            selected += t.name + " ";
        }

        EditorGUILayout.LabelField("Selected Object:", selected);
        selected = "";

        if (GUILayout.Button("Randomize!"))
            RandomizeSelected();

        if (GUILayout.Button("Close"))
            Close();
    }

    void OnInspectorUpdate()
    {
        Repaint();
    }
}
