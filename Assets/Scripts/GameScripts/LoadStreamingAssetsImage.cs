using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 动态加载图片，打包后可随时在包内修改游戏里的图片
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
    /// 根据变量路径来返回精灵图片
    /// </summary>
    /// <param name="objname"></param>
    /// <returns></returns>
    public Sprite LoadImage(string objname)
    {
        string _path = Application.dataPath + "/StreamingAssets/" + objname;//获取地址

        FileStream _fileStream = new FileStream(_path, FileMode.Open, FileAccess.Read);//使用流数据读取

        byte[] _buffur = new byte[_fileStream.Length];

        _fileStream.Read(_buffur, 0, _buffur.Length);//转换成字节流数据

        Texture2D _texture2d = new Texture2D(10, 10);//设置宽高

        _texture2d.LoadImage(_buffur);//将流数据转换成Texture2D

        Sprite _sprite = Sprite.Create(_texture2d, new Rect(0, 0, _texture2d.width, _texture2d.height), Vector3.zero);//创建一个Sprite

        ShowPic.GetComponent<Image>().sprite = _sprite;//赋值

        return _sprite;
    }
}
