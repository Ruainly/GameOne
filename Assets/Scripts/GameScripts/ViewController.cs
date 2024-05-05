using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    // ˮƽ�ӽ��ƶ������ж�
    public float sensitivityHor = 3f;
    // ��ֱ�ӽ��ƶ������ж�
    public float sensitivityVer = 3f;
    // �ӽ������ƶ��ĽǶȷ�Χ����ֵԽС��ΧԽ��
    public float upVer = -45;
    // �ӽ������ƶ��ĽǶȷ�Χ����ֵԽ��ΧԽ��
    public float downVer = 45;
    // ��ֱ��ת�Ƕ�
    private float rotVer;

    // ��ת�ķ�������
    // x ��ʾ�� x ����ת���� ǰ�Ϻ� �ĽǶ�
    // y ��ʾ�� y ����ת���� ��ǰ�� �ĽǶ�
    // y ��ʾ�� y ����ת���� ��ǰ�� �ĽǶ�

    // Start is called before the first frame update
    void Start()
    {
        // ��ʼ����ǰ�Ĵ�ֱ�Ƕ�
        rotVer = transform.eulerAngles.x;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ��ȡ������µ��ƶ�λ��
        float mouseVer = Input.GetAxis("Mouse Y");
        // ��ȡ������ҵ��ƶ�λ��
        float mouseHor = Input.GetAxis("Mouse X");
        // ��������ƶ����ӽ���ʵ�������ƣ�����Ҫ��ﵽ�ӽ�Ҳ�����ƵĻ�����Ҫ��ȥ��
        rotVer -= mouseVer * sensitivityVer;
        // �޶������ƶ����ӽǷ�Χ������ֱ������360����ת
        rotVer = Mathf.Clamp(rotVer, upVer, downVer);
        // ˮƽ�ƶ�
        float rotHor = transform.localEulerAngles.y + mouseHor * sensitivityHor;
        // �����ӽǵ��ƶ�ֵ
        //transform.localEulerAngles = new Vector3(rotVer, rotHor, 0);
        transform.localEulerAngles = new Vector3(rotVer, 0, 0);

    }
}
