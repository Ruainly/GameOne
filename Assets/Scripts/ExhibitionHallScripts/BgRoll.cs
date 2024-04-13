using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgRoll : MonoBehaviour
{
    [Range(0f, 150f)] //将rollSpeed在Inspector面板中设置成滑动条的样式
    public float rollSpeed = 30f;//滚动速度
    public float Up=380; //上边界
    private float Down=0; //左边界
    private float distance; //上左边界距离

    public bool CanPlay = false;

    // Use this for initialization
    void Start()
    {
        //计算左右边界。Bounds是当图形的边界框
        //SpriteRenderer sRender = GetComponent<SpriteRenderer>();
        //Up = transform.position.x + sRender.bounds.extents.y;
        //Down = transform.position.x - sRender.bounds.extents.y;

        //distance = Up - Down;//左右边界相减得到距离
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
            //使背景图片向右移动
            transform.localPosition += rollSpeed * Vector3.up * Time.deltaTime;

            //判断是否到达右边界
            if (transform.localPosition.y >= Up)
            {
                //如果到达，将背景图片的位置向后（y轴方向）调整一个背景图片长度的距离
                //transform.position -= new Vector3(0, distance, 0);
                transform.localPosition = new Vector3(0, 0, 0);
            }
        }
    }
}
