using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExhibitionHall : MonoBehaviour
{
    // Start is called before the first frame update
    Image[] TopsidePic;
    Transform[] Canvas = new Transform[6];
    void Start()
    {
        //for (int i = 0; i < 6; i++)
        //{
        //    Canvas[i] = transform.Find("AllCanvas").GetChild(i);
        //    TopsidePic = new Image[Canvas[i].childCount];
        //    for (int j = 0; j < TopsidePic.Length; j++)
        //    {
        //        TopsidePic[j] = Canvas[i].GetChild(0).GetChild(j).GetComponent<Image>();
        //        Sprite _sprite;
        //        _sprite = transform.GetComponent<LoadStreamingAssetsImage>().LoadImage("×ÊÔ´/´óÍ¼/000-2008/2008.09.16/icon");
        //        TopsidePic[j].sprite = _sprite;
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
