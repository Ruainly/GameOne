using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExhibitionHall_MainController : MonoBehaviour
{
    // Start is called before the first frame update
    Transform AVPro;

    void Start()
    {
        AVPro = transform.GetChild(0);
        //for (int i = 0; i < AVPro.childCount; i++)
        //{
        //    AVPro.GetChild(i).Find("Bg").GetComponent<Button>().onClick.AddListener(() =>
        //    {
        //        AVPro.GetChild(i).Find("BigView/ChangeBtns").GetComponent<AppearOneByOne_Ani>().ScriptAni();
        //    });
        //}
        //for (int i = 0; i < AVPro.childCount; i++) {
        //    int temp = i;
        //    AVPro.GetChild(temp).Find("BigView/Fork").GetComponent<Button>().onClick.AddListener(()=> { 

        //    });
        //};
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ForkAll()
    {

    }
}
