using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

//[CustomEditor(typeof(TestDrag), true)]
//[CanEditMultipleObjects]
//public class TestDrag : EditorWindow
//{
//    public static string path;
//    Rect rect;
//    [MenuItem("Window/TestDrag")]
//    static void Init()
//    {
//        EditorWindow.GetWindow(typeof(TestDrag));
//    }
//    void OnGUI()
//    {
//        EditorGUILayout.LabelField("·��");
//        ���һ����300�Ŀ�
//        rect = EditorGUILayout.GetControlRect(GUILayout.Width(300));
//        ������Ŀ���Ϊ�ı������
//        path = EditorGUI.TextField(rect, path);
//        ������������ק�л���ק����ʱ�������������λ�����ı��������
//        if ((Event.current.type == EventType.DragUpdated
//        || Event.current.type == EventType.DragExited)
//        && rect.Contains(Event.current.mousePosition))
//        {
//            �ı��������
//            DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
//            if (DragAndDrop.paths != null && DragAndDrop.paths.Length > 0)
//            {
//                path = DragAndDrop.paths[0];
//            }
//        }
//    }
//}

public class LoadStreamingAssetsImage : MonoBehaviour
{
    private Image ShowPic;
    public string Path;

    // Start is called before the first frame update
    void Start()
    {
        ShowPic = transform.GetComponent<Image>();
        ShowPic.sprite = LoadImage(Path);
    }

    /// <summary>
    /// ���ݱ���·�������ؾ���ͼƬ
    /// </summary>
    /// <param name="objname"></param>
    /// <returns></returns>
    public Sprite LoadImage(string objname)
    {
        string _path = Application.dataPath + "/StreamingAssets/" + objname;//��ȡ��ַ

        FileStream _fileStream = new FileStream(_path, FileMode.Open, FileAccess.Read);//ʹ�������ݶ�ȡ

        byte[] _buffur = new byte[_fileStream.Length];

        _fileStream.Read(_buffur, 0, _buffur.Length);//ת�����ֽ�������

        Texture2D _texture2d = new Texture2D(10, 10);//���ÿ��

        _texture2d.LoadImage(_buffur);//��������ת����Texture2D

        Sprite _sprite = Sprite.Create(_texture2d, new Rect(0, 0, _texture2d.width, _texture2d.height), Vector3.zero);//����һ��Sprite

        ShowPic.GetComponent<Image>().sprite = _sprite;//��ֵ

        return _sprite;
    }

    //static public LoadStreamingAssetsImage _instance;
    //static public LoadStreamingAssetsImage Instance()
    //{
    //    if (_instance == null)
    //    {
    //        _instance = new LoadStreamingAssetsImage();
    //    }
    //    return _instance;
    //}

}
