using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMaskBehavioralLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public bool CanMove = true;

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
        if (CanMove)
        {
            transform.position += new Vector3(-0.01f, 0, 0);
        }
    }
}
