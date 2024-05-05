using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step1_CollectProPerTry_lanterns : MonoBehaviour
{
    int CollectedLanternsCount = 0;
    public GameObject CameraShouldHere;
    public Transform Buildings;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ProPertry_lantern")
        {
            collision.gameObject.SetActive(false);
            ++CollectedLanternsCount;
            if (CollectedLanternsCount == 3)
            {
                transform.GetComponent<CharacterControl>().enabled = false;
                transform.GetComponent<CharacterController>().enabled = false;
                Cursor.visible = true;
                //transform.Find("Main Camera").GetComponent<ViewController>().enabled = false;
                transform.Find("Plane").gameObject.SetActive(true);
                CameraShouldHere.SetActive(true);
                Buildings.gameObject.SetActive(true);
                GameObject.FindWithTag("MainCamera").SetActive(false);
                //Buildings.GetComponent<HGameManager>().enabled = true;
                GameObject.Find("HuaRongDao").GetComponent<HuaRongDaoController>().enabled = true;
            }
        }
    }
}
