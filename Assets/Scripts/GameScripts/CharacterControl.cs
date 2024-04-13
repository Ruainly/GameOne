using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControl : MonoBehaviour
{
    // ��ȡ����������λ����Ϣ��[SerializeField] ������ java �Ĺ��췽���ķ�������
    [SerializeField] private Transform target;
    // ���������ٶ�
    public float jumpSpeed = 15.0f;
    // ����
    public float gravity = -9.8f;
    // ���մ�ֱ�ٶ�
    public float endsVelocity = -10.0f;
    // �ڵ���ʱ�Ĵ�ֱ�ٶ�
    public float minFall = -1.5f;
    // ���������ٶ�
    public float runSpeed = 10;
    // ��·���ٶ�
    public float walkSpeed = 4;
    // ��ֱ�ٶ�
    private float verSpeed;

    // �ƶ����ٶ�
    private float moveSpeed;
    // ���ڴ洢��ǰ�Ľ�ɫ�ؼ�
    private CharacterController character;


    public float sensitivityHor = 3f;

    // �ڱ�����ʱִ��
    void Start()
    {
        // ��ʼ��
        character =transform.GetComponent<CharacterController>();
        verSpeed = minFall;
        moveSpeed = walkSpeed;
    }
    // ÿ����һ֡ʱִ��
    void Update()
    {
        float mouseHor = Input.GetAxis("Mouse X");
        float rotHor = transform.localEulerAngles.y + mouseHor * sensitivityHor;
        transform.localEulerAngles = new Vector3(0, rotHor, 0);

        // ���ڴ洢�ƶ���Ϣ
        Vector3 movement = Vector3.zero;
        // ��ȡ���ҷ�����ƶ���Ϣ
        float horspeed = Input.GetAxis("Horizontal");
        // ��ȡǰ������ƶ���Ϣ
        float verspeed = Input.GetAxis("Vertical");
        // ���������ƶ���ִ��
        if (horspeed != 0 || verspeed != 0)
        {
            // ��������λ��
            movement.x = horspeed * moveSpeed;
            // ����ǰ���λ��
            movement.z = verspeed * moveSpeed;
            // ����б���ߵ�����ٶȸ�ˮƽ��ֱ�ߵ��ٶ�һ��
            movement = Vector3.ClampMagnitude(movement, moveSpeed);
            // ���ƶ�����Ϣת��Ϊ�������Ϊȫ�������λ�ã�����֤����ǰ��һ������������ӽǷ���
            movement = target.TransformDirection(movement);
        }
        // �������� shift �Ǹ����ٶ�
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }
        // ��ɫ�ؼ��Դ���һ�����������ڼ���Ƿ��ڵ���
        if (character.isGrounded)
        {
            // ���˿ո�������ֱ����ʩ��һ���ٶ�
            if (Input.GetButtonDown("Jump"))
            {
                verSpeed = jumpSpeed;
            }
            else
            {
                verSpeed = minFall;
            }
        }
        else
        {
            // ���Ѿ����������򽫴�ֱ������ٶȵݼ����ͣ����ﵽһ�� ������ ��һ��Ч��
            // Time.deltaTime ��ʾΪÿ���ˢ��Ƶ�ʵĵ�������������ÿ̨���Ե��ƶ��ٶȶ���һ����
            verSpeed += gravity * 3 * Time.deltaTime;
            // �������׹���ٶ�
            if (verSpeed < endsVelocity)
            {
                verSpeed = endsVelocity;
            }
        }
        // ���ƶ�һ����ֱ�ٶ�
        movement.y = verSpeed;
        // �����ٶ�
        movement *= Time.deltaTime;
        // ��ɫ�ؼ��Դ���һ������������ transform.Translate() �Ļ���������ײ��
        character.Move(movement);
    }

}
