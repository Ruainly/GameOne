using UnityEngine;
using System.Collections;
using DG.Tweening;

public class HBlock : MonoBehaviour
{
    //public void OnMouseDown()
    //{
        //if (HGameManager.Instance.CanClick == true)
        //{
        //    HGameManager.Instance.CanClick = false;
        //    Debug.Log(Vector3.Distance(transform.position, HGameManager.Instance.empty));
        //    //判断与空方块的距离,如果不是与空方块相邻的物体这不能交换
        //    if (Vector3.Distance(transform.position, HGameManager.Instance.empty) <= 31f)
        //    {
        //        var temp = transform.position;
        //        transform.DOMove(HGameManager.Instance.empty, 1.5f);//交换位置
        //        transform.GetComponent<AudioSource>().mute = false;
        //        transform.GetComponent<AudioSource>().Play();
        //        transform.Find("Particle_BuildingMove").GetComponent<ParticleSystem>().Play();
        //        DOVirtual.DelayedCall(1.5f,() =>
        //        {
        //            HGameManager.Instance.CanClick = true;
        //            transform.GetComponent<AudioSource>().mute=true;
        //        });
        //        HGameManager.Instance.SwapEmpty(temp);//每次交换都需要根据空方块的位置,进行判定是否已经完成游戏
        //    }
        //}


    //}

}