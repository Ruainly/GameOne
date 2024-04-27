using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class HGameManager : MonoBehaviour
{

    //����ģʽ
    #region single instance

    private static HGameManager instance;
    public static HGameManager Instance { get { return instance; } }

    void Awake()
    {
        instance = this;
    }

    #endregion

    //���������ȴ������ƶ�
    public bool CanClick = true;

    public Transform emptyTransform;//��¼һ��ʼ�Ŀ�λ�õ�����

    [HideInInspector]//����������ص������������
    public Vector3 empty;//�����ƶ�ʱ�洢�Ŀ�λ�õ�����

    public GameObject[] pieces;//�洢��������
    private Vector3[] piecePositions;//�洢���������λ��,�����ж��Ƿ������Ϸ
    private bool isSwaped = false;//��¼�Ƿ����SwapPiece()����,�����ж��Ƿ������Ϸ
    void Start()
    {
        //��ʼ��empty,piecePositions��ֵ
        empty = emptyTransform.position;
        piecePositions = new Vector3[pieces.Length];
        for (int i = 0; i < pieces.Length; i++)
        {
            piecePositions[i] = pieces[i].transform.position;
        }
        SwapPiece();
    }
    public void SwapPiece()//���ҷ���ķ���
    {
        int[] step = { -1, 1, -3, 3 };
        int emptyIndex = pieces.Length - 1;//�հ׷��������
        int i = 0;
        while (i < 1000)//��������������,ÿ���һ�ξͽ�����һ�η���
        {
            var index = emptyIndex + step[Random.Range(0, 4)];
            if (index < 8 && index >= 0)
            {
                //pieces[index].GetComponent<HBlock>().OnMouseDown();
                i++;
            }
            emptyIndex = index;
        }

        isSwaped = true;
    }
    public void SwapEmpty(Vector3 targer)//��Ҫ���ж���Ϸ���
    {
        empty = targer;
        if (emptyTransform.position == empty)
        {
            bool isWin = true;
            for (int i = 0; i < pieces.Length; i++)
            {
                if (pieces[i].transform.position != piecePositions[i])
                {
                    isWin = false;
                    break;
                }
            }
            if (isWin && isSwaped)
            {
                print("Win");
                isSwaped = false;
            }
        }
    }
}