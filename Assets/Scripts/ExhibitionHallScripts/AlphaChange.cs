using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaChange : MonoBehaviour
{
    private float duration=1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        DOTween.To(() => 0f, MyFunc, 1f, duration).SetEase(Ease.Linear).SetAutoKill(false).SetTarget(this);
        Invoke("BgRoll", 1);
    }

    private void OnDisable()
    {
        DOTween.To(() => 1f, MyFunc, 0f, duration).SetEase(Ease.Linear).SetAutoKill(false).SetTarget(this);
    }

    void MyFunc(float value)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Color color = transform.GetChild(i).GetComponent<Image>().color;
            color.a = value;
            transform.GetChild(i).GetComponent<Image>().color = color;
        }
    }

    void BgRoll()
    {
        transform.GetComponent<BgRoll>().CanPlay = true;
    }
    /// <summary>
    /// 渐变透明显示内容图片
    /// </summary>
    public void ShowContent()
    {
        if (transform.gameObject.activeSelf == false)
        {
            transform.gameObject.SetActive(true);
        }
        DOTween.To(() => 0f, MyFunc, 1f, duration).SetEase(Ease.Linear).SetAutoKill(false).SetTarget(this);
    }
}
