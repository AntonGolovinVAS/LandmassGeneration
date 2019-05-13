using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BeginWindows : EditorWindow
{
    string str = "Отметьте начальную область всех всплывающих окон.";

    public Rect windowRect = new Rect(100, 100, 210, 200);
    /*
      GUI.Window ведет себя несколько иначе в редакторе, чем внутри ваших игр. В играх GUI.Window выскакивает окно на вашем экране.
      В редакторе GUI.Window показывает подокно внутри одного из ваших окон редактора. Begin / EndWindows используется, 
      чтобы определить, куда они могут пойти. Вы должны иметь все вызовы GUI.Window или GUILayout.Window внутри BeginWindows / EndWindows пары. Вот так: 
     */

    [MenuItem("Example/ Public Methods/ BeginWindows")]
    static void Init()
    {
        var editorWindow =  GetWindow(typeof(BeginWindows));
        editorWindow.Show();
    }

    void OnGUI()
    {
        GUILayout.TextArea(str);
        BeginWindows();
        windowRect = GUILayout.Window(1, windowRect, DoWindow, "Hi There");
        EndWindows();
    }

    void DoWindow(int unusedWindowID)
    {
        GUILayout.Button("Hi");

        //Делает окно перетаскиваемым.
        //Чтобы сделать окно перетаскиваемым, вставьте вызов данной функции внутри кода обработки окна.
        GUI.DragWindow();
    }
}
