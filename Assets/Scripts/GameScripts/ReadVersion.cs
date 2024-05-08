using System.IO;
using System.Xml;
using UnityEngine;

/// <summary>
/// �԰��޸�������Դ�󣬿����ڰ���ֱ���޸İ汾��
/// </summary>
public class ReadVersion : MonoBehaviour
{
    void Start()
    {
        LoadXml();
    }

    //��ȡXML
    void LoadXml()
    {
        XmlDocument xml = new XmlDocument();
        xml.Load(Application.streamingAssetsPath + "/data.xml");
        XmlNodeList xmlNodeList = xml.SelectSingleNode("Node").ChildNodes;
        //���������ӽڵ�
        foreach (XmlElement xl1 in xmlNodeList)
        {
            if (xl1.GetAttribute("id") == "1")
            {
                //��������idΪ1�Ľڵ��µ��ӽڵ�
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
