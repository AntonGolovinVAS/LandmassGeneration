using UnityEditor;
using UnityEngine;

public class Repaint : EditorWindow
{
    string selecteed = "";
    public float RotationAmount = 0.33f;

    [MenuItem("Example/ Public Methods/ Repaint")]
    static void Init()
    {
        GetWindow<Repaint>(true, "Repaint").ShowUtility();
    }

    private void OnInspectorUpdate()
    {
        Repaint();
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Рандомизировать вращение выбранных объектов.");

        foreach (var trans in Selection.transforms) selecteed += trans.name + "";
        EditorGUILayout.LabelField("Selected Object:", selecteed);
        selecteed = "";
        if (GUILayout.Button("Randomize!"))
        {
            RandomizeSelected();
        }
        if (GUILayout.Button("Close"))
            this.Close();
    }

    void RandomizeSelected()
    {
        foreach (var trans in Selection.transforms)
        {
            var rotation = Random.rotation;
            trans.localRotation = Quaternion.Slerp(trans.localRotation, rotation, RotationAmount);
        }
    }
}
