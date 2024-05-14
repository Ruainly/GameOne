using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedMaskDialog : MonoBehaviour
{
    public GameObject CameraShouldHere;
    public Transform Buildings;
    CanvasGroup Bluer;
    Animator animator;
    GameObject Dialog;
    Text DialogContent;
    public float delay = 0.1f;
    string t1 = "出去的办法就在这里。";
    string t2 = "这些建筑群……似乎可以移动？这难道是一个谜题？";
    string currentText;
    Button Interaction,NextWords;
    Coroutine coroutine1, coroutine2;
    bool CanPressF = false;
    int FCount = 0;
    Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetComponent<Animator>();
        Dialog = GameObject.Find("Canvas").transform.Find("DialogBox").gameObject;
        DialogContent = Dialog.transform.Find("Text").GetComponent<Text>();
        NextWords = Dialog.transform.Find("Next").GetComponent<Button>();
        Interaction= GameObject.Find("Canvas").transform.Find("PressF").GetComponent<Button>();
        Player = GameObject.Find("Player").transform;
        BingdingEvents();
    }

    void BingdingEvents()
    {
        Interaction.onClick.RemoveAllListeners();
        Interaction.onClick.AddListener(() => {
            GameObject.Find("Canvas").transform.Find("PressF").gameObject.SetActive(false);
            Dialog.SetActive(true);
            coroutine1 = StartCoroutine(ShowText(t1));
        });

        NextWords.onClick.AddListener(() =>
        {
            FCount++;
            StopCoroutine(coroutine1);
            currentText = "";
            DialogContent.text = "";
            coroutine2= StartCoroutine(ShowText(t2)); 
            if (FCount == 2)
            {
                OverDialog();
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (CanPressF)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                GameObject.Find("Canvas").transform.Find("PressF").gameObject.SetActive(false);
                Dialog.SetActive(true);
                coroutine1 = StartCoroutine(ShowText(t1));
                CanPressF = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameObject.Find("CMFreeLook").GetComponent<CinemachineFreeLook>().enabled = false;
            transform.GetComponent<RedMaskBehavioralLogic>().CanMove = false;
            animator.SetBool("walk", false);
            animator.SetBool("idle", true);
            Interaction.gameObject.SetActive(true);
            CanPressF = true;
            Cursor.visible = true;
            transform.GetComponent<BoxCollider>().enabled = false;
        }
    }

    IEnumerator ShowText(string t)
    {
        for (int i = 0; i < t.Length; i++)//遍历插入字符串的长度
        {
            currentText = t.Substring(0, i);
            DialogContent.text = currentText;
            yield return new WaitForSeconds(delay);//每次延迟的时间 数值越小 延迟越少
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameObject.Find("CMFreeLook").GetComponent<CinemachineFreeLook>().enabled = true;
            transform.GetComponent<RedMaskBehavioralLogic>().CanMove = true;
            Interaction.gameObject.SetActive(false);
            CanPressF = false;
            Cursor.visible = false;
            transform.GetComponent<BoxCollider>().enabled = true;
        }
    }

    void StartHuaRongDao()
    {
        Player.GetComponent<CharacterControl>().enabled = false;
        Player.GetComponent<CharacterController>().enabled = false;
        Cursor.visible = true;
        Player.Find("Plane").gameObject.SetActive(true);
        CameraShouldHere.SetActive(true);
        Buildings.gameObject.SetActive(true);
        GameObject.Find("HuaRongDao").GetComponent<HuaRongDaoController>().enabled = true;
        Bluer = GameObject.Find("Bluer").GetComponent<CanvasGroup>();
        DOTween.To(() => Bluer.alpha, x => Bluer.alpha = x, 0.1f, 0.5f);
        GameObject.Find("CMFreeLook").GetComponent<CinemachineFreeLook>().enabled = false;
    }


    void OverDialog()
    {
        StopCoroutine(coroutine2);
        currentText = "";
        DialogContent.text = "";
        Dialog.SetActive(false);
        StartHuaRongDao();
    }
}
