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
    bool CanClick=true;
    float Interval=0;

    Vector3 TempPos;
    // Start is called before the first frame update
    void Start()
    {
        _HuaRongDaoController = GameObject.Find("HuaRongDao").GetComponent<HuaRongDaoController>();
        Buildings = GameObject.Find("SmallWorlBuildings").transform;
        //transform.GetComponent<Button>().onClick.AddListener(() => Getsiblingindex(Convert.ToInt16(transform.gameObject.name) - 1));
    }

    /// <summary> 
    /// 判断【数字9（白板）】上下左右的项的索引值，如果是被点击的x，则交换两个索引值里的数据，然后调用函数刷新面板里图块的顺序 
    /// </summary> 
    /// <param name="x">点击图块的索引值</param> -
    void A_exchange(int x)
    {
        int index = Buildings.Find("9").transform.GetSiblingIndex() + 1;
        //Debug.LogError("index: "+index);
        //Debug.LogError("x: " + x);
        if (((index + 1 == x) && !(index % 3 == 0)) || ((index - 1 == x) && !(index % 3 == 1)) || (index + 3 == x) || (index - 3 == x))
        {
            transform.Find("Particle_BuildingMove").GetComponent<ParticleSystem>().Play();
            transform.parent.GetComponent<AudioSource>().Play();
            DOVirtual.DelayedCall(1.1f, () =>
            {
                transform.parent.GetComponent<AudioSource>().Stop();
            });
            transform.parent.GetComponent<AudioSource>().DOPause();
            int temp = _HuaRongDaoController.Array[x - 1];
            _HuaRongDaoController.Array[x - 1] = _HuaRongDaoController.Array[index - 1];
            _HuaRongDaoController.Array[index - 1] = temp;
            TempPos = Buildings.Find("9").position;
            Buildings.Find("9").DOMove(transform.position, 1);
            transform.DOMove(TempPos,1);
            P_sequence(_HuaRongDaoController.Array);
        }
    }

    /// <summary> 
    /// 图块按照数组重新排序 
    /// </summary> 
    /// <param name="gameObject">table</param> 
    /// <param name="a">乱序数组</param> 
    void P_sequence(int[] a)
    {
        foreach (int num in a)
        {
            string name = num.ToString();
            GameObject.Find(name).transform.SetSiblingIndex(-1);
        }
    }
    
    public void BuildDingClick()
    {
        if (CanClick == true)
        {
            CanClick = false;
            A_exchange(transform.GetSiblingIndex() + 1);
            //Debug.Log(transform.name +"被点击");
        }
    }

    private void Update()
    {
        if (CanClick == false)
        {
            Interval += Time.deltaTime;
            if (Interval >= 1.15f)
            {
                CanClick = true;
                Interval = 0;
            }
        }
    }
}
