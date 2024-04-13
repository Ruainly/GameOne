using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowController : MonoBehaviour
{
    GameObject SciFiTownGuard;
    MobilePhoneCollider mobilePhoneCollider;

    // Start is called before the first frame update
    void Start()
    {
        SciFiTownGuard = transform.Find("SciFiTown/SciFiTownGuard").gameObject;
        mobilePhoneCollider = transform.Find("Shou Ji").GetComponent<MobilePhoneCollider>();
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
        mobilePhoneCollider.CameraShouldHere.SetActive(false);
        GameObject.Find("Root").transform.Find("Player/Main Camera").gameObject.SetActive(true);
    }
}
