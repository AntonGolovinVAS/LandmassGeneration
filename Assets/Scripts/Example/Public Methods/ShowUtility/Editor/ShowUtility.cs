using UnityEditor;
using UnityEngine;

public class ShowUtility1 : EditorWindow
{
    public float rotationAmount = 0.33f;
    public string selected = "";

    [MenuItem("Example/ Public Methods/ ShowUtility")]
    static void RandomizeWindow()
    {
        ShowUtility1 window = ScriptableObject.CreateInstance(typeof(ShowUtility1)) as ShowUtility1;
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
