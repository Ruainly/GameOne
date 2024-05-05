using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowController : MonoBehaviour
{
    GameObject SciFiTownGuard;
    Step2_CameraShowCity step2_CameraShowCity;


    // Start is called before the first frame update
    void Start()
    {
        SciFiTownGuard = GameObject.Find("Obstacles").gameObject;
        step2_CameraShowCity = transform.GetComponent<Step2_CameraShowCity>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.A))
        {
            HuaRongDaoFinishi();
        }
    }

    public void HuaRongDaoFinishi()
    {
        SciFiTownGuard.SetActive(false);
        Cursor.visible = false;
        //transform.GetComponent<CharacterControl>().enabled = false;
        //transform.GetComponent<CharacterController>().enabled = false;
        //transform.Find("Player/Main Camera").gameObject.SetActive(true);
        //mobilePhoneCollider.CameraShouldHere.SetActive(false);
        
        transform.Find("Player/SmallWorldCamera").gameObject.SetActive(false);
        transform.Find("Player/SmallWorlBuildings").gameObject.SetActive(false);
        step2_CameraShowCity.enabled = true;
    }
}
