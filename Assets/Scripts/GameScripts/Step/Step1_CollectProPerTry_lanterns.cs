using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Cinemachine;

public class Step1_CollectProPerTry_lanterns : MonoBehaviour
{
    int CollectedLanternsCount = 0;
    public GameObject CameraShouldHere, Lanterns;
    public Transform Buildings;
    CanvasGroup Bluer;
    Text CollectedText;
    bool isLight=true;
    // Start is called before the first frame update
    void Start()
    {
        CollectedText = GameObject.Find("CollectedText").GetComponent<Text>();
        Lanterns = GameObject.Find("ProPertry").gameObject;
        CyclicLuminescence();
    }

    // Update is called once per frame
    void Update()
    {
        CollectedText.text = CollectedLanternsCount + "/3";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ProPertry_lantern")
        {
            collision.gameObject.SetActive(false);
            ++CollectedLanternsCount;
            if (CollectedLanternsCount == 3)
            {
                //StartHuaRongDao();
                CollectedText.gameObject.SetActive(false);
                Lanterns.SetActive(false);
                GameObject.Find("RedMask").GetComponent<RedMaskDialog>().enabled = true;
            }
        }
    }

    void StartHuaRongDao()
    {
        transform.GetComponent<CharacterControl>().enabled = false;
        transform.GetComponent<CharacterController>().enabled = false;
        Cursor.visible = true;
        //transform.Find("Main Camera").GetComponent<ViewController>().enabled = false;
        transform.Find("Plane").gameObject.SetActive(true);
        CameraShouldHere.SetActive(true);
        Buildings.gameObject.SetActive(true);
        //GameObject.FindWithTag("MainCamera").SetActive(false);
        GameObject.Find("CMFreeLook").GetComponent<CinemachineFreeLook>().enabled = false;
        //Buildings.GetComponent<HGameManager>().enabled = true;
        GameObject.Find("HuaRongDao").GetComponent<HuaRongDaoController>().enabled = true;
        Bluer = GameObject.Find("Bluer").GetComponent<CanvasGroup>();
        DOTween.To(() => Bluer.alpha, x => Bluer.alpha = x, 0.1f, 0.5f);
    }

    void CyclicLuminescence()
    {
        if (Lanterns.activeSelf == true)
        {
            for (int i = 0; i < Lanterns.transform.childCount; i++)
            {
                if (isLight == false)
                {
                    isLight = true;
                    Lanterns.transform.GetChild(i).GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                }
                else
                {
                    isLight = false;
                    Lanterns.transform.GetChild(i).GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                }
            }
            DOVirtual.DelayedCall(0.7f,() =>
            {
                CyclicLuminescence();
            });
        }
    }
}
