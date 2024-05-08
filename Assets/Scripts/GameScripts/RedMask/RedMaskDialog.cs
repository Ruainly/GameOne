using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedMaskDialog : MonoBehaviour
{
    Animator animator;
    GameObject Dialog;
    Text DialogContent;
    public float delay = 0.1f;
    string t1 = "�ۣ���⿪�ˣ����������";
    string t2 = "лл�����������ĺ���Ȥ��";
    string currentText;
    Button Interaction,NextWords;
    Coroutine coroutine1, coroutine2;
    bool CanPressF = false;
    int FCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator= transform.GetComponent<Animator>();
        Dialog = GameObject.Find("Canvas").transform.Find("DialogBox").gameObject;
        DialogContent = Dialog.transform.Find("Text").GetComponent<Text>();
        NextWords = Dialog.transform.Find("Next").GetComponent<Button>();
        Interaction= GameObject.Find("Canvas").transform.Find("PressF").GetComponent<Button>();
        BingdingEvents();
    }

    void BingdingEvents()
    {
        Interaction.onClick.RemoveAllListeners();
        Interaction.onClick.AddListener(() => {
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
                StopCoroutine(coroutine2);
                currentText = "";
                DialogContent.text = "";
                Cursor.visible = false;
                Dialog.SetActive(false);
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
                Dialog.SetActive(true);
                coroutine1 = StartCoroutine(ShowText(t1));
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameObject.Find("Main Camera").GetComponent<ViewController>().enabled = false;
            transform.GetComponent<RedMaskBehavioralLogic>().CanMove = false;
            animator.SetBool("walk", false);
            animator.SetBool("idle", true);
            Interaction.gameObject.SetActive(true);
            CanPressF = true;
            Cursor.visible = true;
        }
    }

    IEnumerator ShowText(string t)
    {
        for (int i = 0; i < t.Length; i++)//���������ַ����ĳ���
        {
            currentText = t.Substring(0, i);
            DialogContent.text = currentText;
            yield return new WaitForSeconds(delay);//ÿ���ӳٵ�ʱ�� ��ֵԽС �ӳ�Խ��
        }
    }
}
