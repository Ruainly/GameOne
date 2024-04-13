using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearOneByOne_Ani_2018 : MonoBehaviour
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
        OriPos=new Vector3[transform.childCount];
        for (int i = Images.Length-1; i >= 0; i--)
        {
            Images[i] = transform.GetChild(i).GetComponent<RectTransform>();
            OriPos[i] = Images[i].localPosition;
            TempPos[i] = (Images[i].localPosition- new Vector3(10, -98, 0)).normalized*30 + Images[i].localPosition;
        }

        DOVirtual.DelayedCall(0.8f, () =>
        {
            Images[8].gameObject.SetActive(true);
            Images[8].DOLocalMove(TempPos[8], 0.3f);
            DOVirtual.DelayedCall(0.2f, () =>
            {
                Images[8].DOLocalMove(OriPos[8], 0.2f);
                Images[7].gameObject.SetActive(true);
                Images[7].DOLocalMove(TempPos[7], 0.3f);
                DOVirtual.DelayedCall(0.2f, () =>
                {
                    Images[7].DOLocalMove(OriPos[7], 0.2f);
                    Images[6].gameObject.SetActive(true);
                    Images[6].DOLocalMove(TempPos[6], 0.3f);
                    DOVirtual.DelayedCall(0.2f, () =>
                    {
                        Images[6].DOLocalMove(OriPos[6], 0.2f);
                        Images[5].gameObject.SetActive(true);
                        Images[5].DOLocalMove(TempPos[5], 0.3f);
                        DOVirtual.DelayedCall(0.2f, () =>
                        {
                            Images[5].DOLocalMove(OriPos[5], 0.2f);
                            Images[4].gameObject.SetActive(true);
                            Images[4].DOLocalMove(TempPos[4], 0.3f);
                            DOVirtual.DelayedCall(0.2f, () =>
                            {
                                Images[4].DOLocalMove(OriPos[4], 0.2f);
                                Images[3].gameObject.SetActive(true);
                                Images[3].DOLocalMove(TempPos[3], 0.3f);
                                DOVirtual.DelayedCall(0.2f, () =>
                                {
                                    Images[3].DOLocalMove(OriPos[3], 0.2f);
                                    Images[2].gameObject.SetActive(true);
                                    Images[2].DOLocalMove(TempPos[2], 0.3f);
                                    DOVirtual.DelayedCall(0.2f, () =>
                                    {
                                        Images[2].DOLocalMove(OriPos[2], 0.2f);
                                        Images[1].gameObject.SetActive(true);
                                        Images[1].DOLocalMove(TempPos[1], 0.3f);
                                        DOVirtual.DelayedCall(0.2f, () =>
                                        {
                                            Images[1].DOLocalMove(OriPos[1], 0.2f);
                                            Images[0].gameObject.SetActive(true);
                                            Images[0].DOLocalMove(TempPos[0], 0.3f);
                                            DOVirtual.DelayedCall(0.2f, () =>
                                            {
                                                Images[0].DOLocalMove(OriPos[0], 0.2f);
                                            });
                                        });
                                    });
                                });
                            });
                        });
                    });
                });
            });
        });
    }

    public void CloseBigView_ChangeBtns()
    {
        DOVirtual.DelayedCall(1, () =>
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }

        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
