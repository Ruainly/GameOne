using UnityEngine;
using System.Collections;
using UnityEditor;

//public class TestDrag : EditorWindow
//{

//    string path;
//    Rect rect;

//    [MenuItem("Window/TestDrag")]
//    static void Init()
//    {
//        EditorWindow.GetWindow(typeof(TestDrag));
//    }

//    void OnGUI()
//    {
//        EditorGUILayout.LabelField("·��");
//        //���һ����300�Ŀ�
//        rect = EditorGUILayout.GetControlRect(GUILayout.Width(300));
//        //������Ŀ���Ϊ�ı������
//        path = EditorGUI.TextField(rect, path);

//        //������������ק�л���ק����ʱ�������������λ�����ı��������
//        if ((Event.current.type == EventType.DragUpdated
//          || Event.current.type == EventType.DragExited)
//          && rect.Contains(Event.current.mousePosition))
//        {
//            //�ı��������
//            DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
//            if (DragAndDrop.paths != null && DragAndDrop.paths.Length > 0)
//            {
//                path = DragAndDrop.paths[0];
//            }
//        }
//    }
//}