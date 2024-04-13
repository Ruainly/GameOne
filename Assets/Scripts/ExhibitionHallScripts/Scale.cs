using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scale : MonoBehaviour
{
    public float ScaleSize = 1;

    private GameObject[] YearTittles;
    // Start is called before the first frame update
    void Start()
    {
        YearTittles = GameObject.FindGameObjectsWithTag("YearTittle");
        for (int i = 0; i < YearTittles.Length; i++)
        {
            YearTittles[i].SetActive(false);
        }
    }

    public void TOnEnable()
    {
        transform.DOScale(ScaleSize, 0.7f);
    }

    public void TOnDisable()
    {
        transform.DOScale(0, 0.7f);
        
        //for (int i = 0; i < transform.GetChild(0).childCount; i++)
        //{
        //    transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
        //    transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        //}

        //for (int i = 0; i < transform.GetChild(1).childCount; i++)
        //{
        //    transform.GetChild(1).GetChild(i).gameObject.SetActive(false);
        //    transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
        //}

    }

    // Update is called once per frame
    void Update()
    {
        //if (transform.localScale != new Vector3(1, 1, 1))
        //{

        //} 
    }

    /// <summary>
    /// 关闭所有滚动页,包含滚动页的按钮
    /// </summary>
    public void CloseAllContains()
    {
        for (int i = 0; i < transform.Find("Mask").childCount; i++)
        {
            transform.Find("Mask").GetChild(i).gameObject.SetActive(false);
        }

        for (int i = 0; i < transform.Find("ChangeBtns").childCount; i++)
        {
            transform.Find("ChangeBtns").GetChild(i).gameObject.SetActive(false);
        }

        YearTittles = GameObject.FindGameObjectsWithTag("YearTittle");
        for (int i = 0; i < YearTittles.Length; i++)
        {
            YearTittles[i].SetActive(false);
        }
    }
}
