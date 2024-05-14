using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HuaRongDaoController : MonoBehaviour
{
    public int[] Array;
    private int[] Order,Ori;
    float alpha = 0;
    bool GStart, Over;
    Vector3[] BuildingPos = new Vector3[9];

    Camera camera;
    Button ResetBtn;
    CanvasGroup Arrow;
    Transform CurrentOne, NextOne,Buildings, Panel;
    void Start()
    {
        //Panel=transform.Find("Panel");
        //camera = GameObject.Find("SmallWorldCamera").GetComponent<Camera>();
        //ResetBtn = Panel.Find("ResetButton").GetComponent<Button>();

        //ResetBtn.onClick.AddListener(() =>
        //{
        //    P_sequence(Ori);
        //});
    }

    private void OnEnable()
    {
        Buildings = GameObject.Find("SmallWorlBuildings").transform;
        Panel = transform.Find("Panel");
        camera = GameObject.Find("SmallWorldCamera").GetComponent<Camera>();
        Arrow = Panel.Find("Arrow").GetComponent<CanvasGroup>();
        ResetBtn = Panel.Find("ResetButton").GetComponent<Button>();
        for (int k=0; k < 9; k++)
        {
            BuildingPos[k] = GameObject.Find("SmallWorlBuildings").transform.GetChild(k).transform.position;
            //Debug.LogError("BuildingPos[" + k + "]: " + BuildingPos[k]);
        }

        StartGame();
        ResetBtn.onClick.AddListener(() =>
        {
            Array=Ori;
            P_sequence(Array);
            for (int k = 0; k < 9; k++)
            {
                 GameObject.Find("SmallWorlBuildings").transform.GetChild(k).transform.position= BuildingPos[k];
                 //Debug.LogError("position:  " + GameObject.Find("SmallWorlBuildings").transform.GetChild(k).transform.position);
            }
        });
    }

    public void StartGame()
    {
        Panel.gameObject.SetActive(true);
        Array = new int[] { 1, 2, 3, 4, 5, 6, 7, 9, 8 };//����{ 1, 2, 6, 7, 4, 5, 8, 3, 9 }
        Ori = new int[] { 1, 2, 3, 4, 5, 6, 7, 9, 8 };
        Order = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        //A_random(Array, 16);//�������

        for (int i = 0; i < Buildings.childCount; i++) {
            if (!Buildings.GetChild(i).TryGetComponent<HuaRongDao>(out HuaRongDao huaRongDao))
            {
                Buildings.GetChild(i).gameObject.AddComponent<HuaRongDao>();
                if (i == 8)
                {
                    //P_sequence(Array);
                    Debug.Log("��ͼ���������ܿ�ʼ");
                }
            }
        }

        //2D
        //GStart = true;
        //DOTween.To(() => alpha, x => alpha = x, 1, 1);
        //DOVirtual.DelayedCall(1, () =>
        //{
        //    GStart = false;
        //});

    }

    // Update is called once per frame
    void Update()
    {
        //2D
        //if (GStart == true || Over == true)
        //{
        //    transform.GetComponent<CanvasGroup>().alpha = alpha;
        //}

        if (Arrow.gameObject.activeSelf == true)
        {
            if (Arrow.alpha == 1)
            {
                DOTween.To(() => Arrow.alpha, x => Arrow.alpha = x, 0, 0.5f);
                if (Arrow.alpha < 0.01f)
                {
                    Arrow.alpha = 0;
                }
            }
            if(Arrow.alpha==0)
            {
                DOTween.To(() => Arrow.alpha, x => Arrow.alpha = x, 1, 0.5f);
                if (Arrow.alpha > 0.99f)
                {
                    Arrow.alpha = 1;
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "SmallWorld")
                {
                    hit.collider.GetComponent<HuaRongDao>().BuildDingClick();
                }
            }
        }

        //����Ƿ�ԭ�ɹ�
        if (Enumerable.SequenceEqual(Array, Order))
        {
            RestoreSuccess();
        }

        if (Input.GetKey(KeyCode.LeftShift)&& Input.GetKey(KeyCode.LeftControl)&& Input.GetKey(KeyCode.F))
        {
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
        for(int i = 0; i < a.Length; i++)
        {
            string name = a[i].ToString();
            GameObject.Find(name).transform.SetSiblingIndex(i);
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
        //2D
        //Over = true;
        //DOTween.To(() => alpha, x => alpha = x, 0, 1);
        //DOVirtual.DelayedCall(1, () =>
        //{
        //    Over = false;
        //    transform.gameObject.SetActive(false);
        //});
        Debug.Log("���ܽ���");
        DOVirtual.DelayedCall(1.5f, () =>
        {
            GameObject.Find("Root").GetComponent<FlowController>().HuaRongDaoFinishi();
            transform.Find("Panel").gameObject.SetActive(false);
            this.enabled = false;
        });
    }
}
