using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playecontrol : MonoBehaviour
{
    private Animator Anim;
    private CharacterController ctrl;
    //private CapsuleCollider ctrl;
    public float speed = 6.0f;
    public float turnSpeed = 60.0f;
    private Vector3 moveDirection = Vector3.zero;
    public float gravity = 20.0f;

    void Start()
    {
        Anim = gameObject.GetComponentInChildren<Animator>();
        ctrl = GetComponent<CharacterController>();
        //ctrl = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            Anim.SetFloat("Blend", 1);
        } 
        else if (Input.GetKey("down"))
        {
            Anim.SetFloat("Blend", -1);
        }
        else Anim.SetFloat("Blend", 0);

        if (ctrl.isGrounded)
        {
            moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
        }
        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
        ctrl.Move(moveDirection * Time.deltaTime);
        moveDirection.y -= gravity * Time.deltaTime;
    }
}