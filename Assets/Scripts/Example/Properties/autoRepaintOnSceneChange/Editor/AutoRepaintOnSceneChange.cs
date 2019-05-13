using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AutoRepaintOnSceneChange : EditorWindow
{

    string str = "Окно редактора, которое отображает то, что «видит» основная камера. Окно автоматически перерисовывается при изменении сцены.";

    Camera camera;
    RenderTexture renderTexture;

    [MenuItem("Example/ Properties/ AutoRepaintOnSceneChange")]
    static void Init()
    {
        EditorWindow editorWindow = GetWindow(typeof(AutoRepaintOnSceneChange));
        editorWindow.autoRepaintOnSceneChange = true;
        editorWindow.Show();
    }

    public void Awake()
    {
        renderTexture = new RenderTexture(500,
            500,
            (int)RenderTextureFormat.ARGB32);
    }

    public void OnEnable()
    {
        camera = Camera.main;
    }

    public void Update()
    {
        if (camera != null)
        {
            camera.targetTexture = renderTexture;
            camera.Render();
            camera.targetTexture = null;
        }
        if (renderTexture.width != position.width ||
            renderTexture.height != position.height)
            renderTexture = new RenderTexture(500,
               500,
                (int)RenderTextureFormat.ARGB32);
    }
    
    void OnGUI()
    {
        GUILayout.TextArea(str);
        GUI.DrawTexture(new Rect(0f, 0f, 500, 500), renderTexture);
    }
}
