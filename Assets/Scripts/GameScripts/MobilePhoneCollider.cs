using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePhoneCollider : MonoBehaviour
{
    public GameObject CameraShouldHere;
    public Transform Buildings;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name == "Player")
        {
            //UI°æ»ªÈÝµÀ
            //transform.GetComponent<BoxCollider>().enabled = false;
            //GameObject.Find("HuaRongDao").GetComponent<HuaRongDaoController>().enabled = true;

            CameraShouldHere.SetActive(true);
            GameObject.FindWithTag("MainCamera").SetActive(false);
            Buildings.GetComponent<HGameManager>().enabled = true;
        }
        
    }
}
