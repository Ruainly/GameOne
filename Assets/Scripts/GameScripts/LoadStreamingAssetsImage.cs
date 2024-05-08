using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ��̬����ͼƬ����������ʱ�ڰ����޸���Ϸ���ͼƬ
/// </summary>
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
}
