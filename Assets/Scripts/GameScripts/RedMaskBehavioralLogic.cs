using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMaskBehavioralLogic : MonoBehaviour
{
    // Start is called before the first frame update

    Animator animator;
    void Start()
    {
        animator = transform.GetComponent<Animator>();
        animator.speed = 0.7f;
        animator.SetBool("walk", true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-0.01f, 0, 0);
    }
}
