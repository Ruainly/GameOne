using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgRoll : MonoBehaviour
{
    [Range(0f, 150f)] //��rollSpeed��Inspector��������óɻ���������ʽ
    public float rollSpeed = 30f;//�����ٶ�
    public float Up=380; //�ϱ߽�
    private float Down=0; //��߽�
    private float distance; //����߽����

    public bool CanPlay = false;

    // Use this for initialization
    void Start()
    {
        //�������ұ߽硣Bounds�ǵ�ͼ�εı߽��
        //SpriteRenderer sRender = GetComponent<SpriteRenderer>();
        //Up = transform.position.x + sRender.bounds.extents.y;
        //Down = transform.position.x - sRender.bounds.extents.y;

        //distance = Up - Down;//���ұ߽�����õ�����
    }

    private void OnDisable()
    {
        transform.localPosition = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.parent.localScale != new Vector3(1, 1, 1))
        {
            CanPlay = false;
            transform.localPosition = new Vector3(0, 0, 0);
        }

        if (CanPlay)
        {
            //ʹ����ͼƬ�����ƶ�
            transform.localPosition += rollSpeed * Vector3.up * Time.deltaTime;

            //�ж��Ƿ񵽴��ұ߽�
            if (transform.localPosition.y >= Up)
            {
                //������������ͼƬ��λ�����y�᷽�򣩵���һ������ͼƬ���ȵľ���
                //transform.position -= new Vector3(0, distance, 0);
                transform.localPosition = new Vector3(0, 0, 0);
            }
        }
    }
}
