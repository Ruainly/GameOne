using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class HuaRongDao : MonoBehaviour
{
    HuaRongDaoController _HuaRongDaoController;
    Transform Buildings;

    Vector3 TempPos;
    // Start is called before the first frame update
    void Start()
    {
        _HuaRongDaoController = GameObject.Find("HuaRongDao").GetComponent<HuaRongDaoController>();
        Buildings = GameObject.Find("SmallWorlBuildings").transform;
        //transform.GetComponent<Button>().onClick.AddListener(() => Getsiblingindex(Convert.ToInt16(transform.gameObject.name) - 1));
    }

    /// <summary> 
    /// ��ȡ����num��ӦArray������ֵ��table�����������ֵ 
    /// </summary> 
    /// <param name="num"></param> 
    public void Getsiblingindex(int num)
    {
        int s = Buildings.GetChild(num).GetSiblingIndex();
        A_exchange(s+1);
    }

    /// <summary> 
    /// �жϡ�����9���װ壩���������ҵ��������ֵ������Ǳ������x���򽻻���������ֵ������ݣ�Ȼ����ú���ˢ�������ͼ���˳�� 
    /// </summary> 
    /// <param name="x">���ͼ�������ֵ</param> 
    void A_exchange(int x)
    {
        int index = Buildings.Find("9").transform.GetSiblingIndex() + 1;
        Debug.LogError("����");
        if (((index + 1 == x) && !(index % 3 == 0)) || ((index - 1 == x) && !(index % 3 == 1)) || (index + 3 == x) && (index < 7) || (index - 3 == x) && (index > 3))
        {
            Debug.LogError("Index�װ�9:" + index);
            Debug.LogError("���+1�汾:" + x);
            int temp = _HuaRongDaoController.Array[x - 1];
            _HuaRongDaoController.Array[x - 1] = _HuaRongDaoController.Array[index - 1];
            _HuaRongDaoController.Array[index - 1] = temp;
            TempPos = Buildings.Find("9").position;
            Buildings.Find("9").position = Buildings.Find(x.ToString()).position;
            Buildings.Find(x.ToString()).position = TempPos;
            P_sequence(_HuaRongDaoController.Array);
        }
    }

    /// <summary> 
    /// ͼ�鰴�������������� 
    /// </summary> 
    /// <param name="gameObject">table</param> 
    /// <param name="a">��������</param> 
    void P_sequence(int[] a)
    {
        foreach (int num in a)
        {
            string name = num.ToString();
            GameObject.Find(name).transform.SetSiblingIndex(-1);
        }
    }

    /// <summary>
    /// �����������
    /// </summary>
    public void OnMouseDown()
    {
        Debug.LogError(11111);
        Getsiblingindex(Convert.ToInt16(transform.gameObject.name) - 1);
    }
}
