using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearOneByOne_Ani : MonoBehaviour
{

    //public RectTransform RelativeObject;
    RectTransform[] Images;
    Vector3[] TempPos;
    Vector3[] OriPos;
    Tween t;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// 根据相对物体的方向弹出物体的代码动画
    /// </summary>
    public void ScriptAni()
    {
        Images = new RectTransform[transform.childCount];
        TempPos = new Vector3[transform.childCount];
        OriPos = new Vector3[transform.childCount];
        for (int i = Images.Length - 1; i >= 0; i--)
        {
            Images[i] = transform.GetChild(i).GetComponent<RectTransform>();
            OriPos[i] = Images[i].localPosition;
            TempPos[i] = (Images[i].localPosition - new Vector3(10, -98, 0)).normalized * 30 + Images[i].localPosition;
        }

        DOVirtual.DelayedCall(0.8f, () =>
        {
            if (transform.childCount > 1)
            {
                //for (int i = Images.Length - 1; i >= 1; i-=2)
                //{
                //    int temp = i;
                //    Images[temp].gameObject.SetActive(true);
                //    Images[temp].DOLocalMove(TempPos[temp], 0.3f);
                //    DOVirtual.DelayedCall(0.2f, () =>
                //    {
                //        Images[temp].DOLocalMove(OriPos[temp], 0.2f);
                //        Images[temp - 1].gameObject.SetActive(true);
                //        Images[temp - 1].DOLocalMove(TempPos[temp-1], 0.3f);
                //        DOVirtual.DelayedCall(0.2f, () =>
                //        {
                //            Images[temp - 1].DOLocalMove(OriPos[temp - 1], 0.2f);
                //        });
                //    });
                //}
                ChangeAction(Images.Length - 1);
            }
            else
            {
                Images[0].gameObject.SetActive(true);
                Images[0].DOLocalMove(TempPos[0], 0.3f);
                DOVirtual.DelayedCall(0.2f, () =>
                {
                    Images[0].DOLocalMove(OriPos[0], 0.2f);
                });
            }
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChangeAction(int i) {
        Images[i].gameObject.SetActive(true);
        Images[i].DOLocalMove(TempPos[i], 0.3f);
        DOVirtual.DelayedCall(0.2f, () =>
        {
            Images[i].DOLocalMove(OriPos[i], 0.2f);
            if (i !=0)
            {
                ChangeAction(i-=1);
            }
        });
    }
}
