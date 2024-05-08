using System.IO;
using System.Xml;
using UnityEngine;

/// <summary>
/// 对包修改美术资源后，可以在包上直接修改版本号
/// </summary>
public class ReadVersion : MonoBehaviour
{
    void Start()
    {
        LoadXml();
    }

    //读取XML
    void LoadXml()
    {
        XmlDocument xml = new XmlDocument();
        xml.Load(Application.streamingAssetsPath + "/data.xml");
        XmlNodeList xmlNodeList = xml.SelectSingleNode("Node").ChildNodes;
        //遍历所有子节点
        foreach (XmlElement xl1 in xmlNodeList)
        {
            if (xl1.GetAttribute("id") == "1")
            {
                //继续遍历id为1的节点下的子节点
                foreach (XmlElement xl2 in xl1.ChildNodes)
                {
                    if (xl2.GetAttribute("Version") == "")
                    {
                        Debug.Log(xl2.InnerText);
                    }
                }
            }
        }
    }
}
