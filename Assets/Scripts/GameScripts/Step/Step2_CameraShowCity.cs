using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Step2_CameraShowCity : MonoBehaviour
{
    GameObject Player, DisplayCamera;
    // Start is called before the first frame update
    void Start()
    {
        Player = transform.Find("Player").gameObject;
        DisplayCamera = transform.Find("Cameras/DisplayCamera").gameObject;
        DisplayCamera.SetActive(true);
        Player.SetActive(false);
        ShowCity();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 结束相机漫游展示
    /// </summary>
    void OverShowCity()
    {
        Cursor.visible = false;
        Player.transform.GetComponent<CharacterControl>().enabled = true;
        Player.transform.GetComponent<CharacterController>().enabled = true;
        Player.transform.Find("Plane").gameObject.SetActive(false);
        Player.SetActive(true);
        GameObject.Find("Player").transform.Find("Main Camera").gameObject.SetActive(true);
        DisplayCamera.SetActive(false);
        transform.Find("Characters/RedMask").GetComponent<RedMaskBehavioralLogic>().enabled = true;
    }

    /// <summary>
    /// 相机漫游展示
    /// </summary>
    void ShowCity()
    {
        DisplayCamera.transform.DOLocalMove(new Vector3(7.542f, 6.81f, -0.313f), 2) ;
        DOVirtual.DelayedCall(2.5f,() =>
        {
            DisplayCamera.transform.DOLocalMove(new Vector3(15.25f, 6.81f, 12.731f), 3);
            DisplayCamera.transform.DOLocalRotate(new Vector3(0, 30.604f, 0), 1);
            DOVirtual.DelayedCall(3f, () => {
                DisplayCamera.transform.DOLocalMove(new Vector3(-16.02f, 6.81f, 12.73f), 3);
                DisplayCamera.transform.DOLocalRotate(new Vector3(0, -90f, 0), 1);
                DOVirtual.DelayedCall(3.5f, () => {
                    DisplayCamera.transform.localPosition = new Vector3(-43.48f, 25.97f, 64.29f);
                    DisplayCamera.transform.localEulerAngles = new Vector3(18.901f, 153.656f, 0);
                    DisplayCamera.transform.DOLocalMove(new Vector3(-46.36f, 28.19f, 70.1f), 2);
                    DOVirtual.DelayedCall(2.5f, () => {
                        OverShowCity();
                    });
                });
            });
        });
    }
}
