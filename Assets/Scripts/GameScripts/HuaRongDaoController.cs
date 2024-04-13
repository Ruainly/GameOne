using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HuaRongDaoController : MonoBehaviour
{
    public int[] Array;
    private int[] Order;

    float alpha = 0;

    bool GStart, Over;
    void Start()
    {

    }

    private void OnEnable()
    {
        StartGame();
    }

    public void StartGame()
    {
        Array = new int[] { 1, 2, 6, 7, 4, 5, 8, 3, 9 };
        Order = new int[] { 1, 2, 9, 4, 5, 6, 7, 8, 3 };
        //A_random(Array, 16);//�������

        for (int i = 0; i < transform.Find("table").childCount; i++) {
            if (!transform.Find("table").GetChild(i).TryGetComponent<HuaRongDao>(out HuaRongDao huaRongDao))
            {
                transform.Find("table").GetChild(i).gameObject.AddComponent<HuaRongDao>();
                if (i == 8)
                {
                    P_sequence(Array);
                    Debug.LogError("11");
                }
            }
        }

        GStart = true;
        DOTween.To(() => alpha, x => alpha = x, 1, 1);
        DOVirtual.DelayedCall(1, () =>
        {
            GStart = false;
        });

    }

    // Update is called once per frame
    void Update()
    {
        if (GStart == true || Over == true)
        {
            transform.GetComponent<CanvasGroup>().alpha = alpha;
        }

        //����Ƿ�ԭ�ɹ�
        if (Enumerable.SequenceEqual(Array, Order))
        {
            RestoreSuccess();
        }

        if (Input.GetKey(KeyCode.LeftShift)&& Input.GetKey(KeyCode.LeftControl)&& Input.GetKey(KeyCode.F))
        {
            Debug.LogError("111");
            RestoreSuccess();
        }
    }
    

    /// <summary> 
    /// ���������������������� 
    /// </summary> 
    /// <param name="a">����</param> 
    /// <param name="temptimes">��������</param> 
    void A_random(int[] a, int temptimes)
    {
        for (int i = 0; i < temptimes; i++)
        {
            int r = Random.Range(0, a.Length);
            int temp = a[i];
            a[i] = a[r];
        }
        foreach (int num in a)
        {
            Debug.Log(num);
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
    /// �жϡ�����9���װ壩���������ҵ��������ֵ������Ǳ������x���򽻻���������ֵ������ݣ�Ȼ����ú���ˢ�������ͼ���˳�� 
    /// </summary> 
    /// <param name="x">���ͼ�������ֵ</param> 
    void A_exchange(int x)
    {
        int index = GameObject.Find("9").transform.GetSiblingIndex() + 1;
        if (((index == x - 1) && !(index % 3 == 0)) || ((index == x + 1) && !(index % 3 == 1)) || (index + 3 == x) || (index - 3 == x))
        {
            int temp = Array[x - 1];
            Array[x - 1] = Array[index - 1];
            Array[index - 1] = temp;
            P_sequence(Array);
        }
    }

    /// <summary>
    /// ��ԭ�ɹ�
    /// </summary>
    void RestoreSuccess()
    {
        //�ɹ�
        Over = true;
        DOTween.To(() => alpha, x => alpha = x, 0, 1);
        DOVirtual.DelayedCall(1, () =>
        {
            Over = false;
            transform.gameObject.SetActive(false);
        });
        Debug.Log("�ɹ�");
        GameObject.Find("Root").GetComponent<FlowController>().HuaRongDaoFinishi();
    }
}
