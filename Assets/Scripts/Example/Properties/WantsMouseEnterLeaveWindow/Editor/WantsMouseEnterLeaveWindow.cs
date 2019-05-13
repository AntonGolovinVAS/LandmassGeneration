using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; 

public class WantsMouseEnterLeaveWindow : EditorWindow
{
    //Проверяет, получены ли события MouseEnterWindow и MouseLeaveWindow в графическом интерфейсе в этом окне редактора.

    //Если установлено значение true, окно получает вызов OnGUI всякий раз, когда мышь входит в окно или покидает его.
    //Эта функция не запускает функцию Repaint () автоматически. Кроме того, 
    //вход в окно или выход из него при нажатой кнопке мыши не приводит ни к какому событию,
    //так как нажатие кнопки мыши активирует режим перетаскивания (см. EventType.MouseDrag 

    string str = "Проверяет, получены ли события MouseEnterWindow и MouseLeaveWindow в графическом интерфейсе в этом окне редактора";

    [MenuItem("Example/ Properties/ WantsMouseEnterLeaveWindow")]
    static void Init()
    {
        //GetWindow<Position>("Позиция");
        var editorWindow = GetWindow<WantsMouseEnterLeaveWindow>();
        editorWindow.Show();
    }

    public void OnGUI()
    {
        GUILayout.TextArea(str);
        wantsMouseEnterLeaveWindow = EditorGUILayout.Toggle("Receive enter/ leave: ", wantsMouseEnterLeaveWindow);
        EditorGUILayout.LabelField("Check Console for MouseEnter/LeaveWindow messages");
        if (Event.current.type == EventType.MouseEnterWindow || Event.current.type == EventType.MouseLeaveWindow)
        {
            Debug.Log("Received event " +
                ((Event.current.type == EventType.MouseEnterWindow) ? "MouseEnterWindow" : "MouseLeaveWindow"));
            Repaint();
        }
    }
}
