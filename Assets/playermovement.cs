using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float speed = 6.0f;
    public float runspeed = 10;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    public Transform Follower;
    public Animator anim;
    public bool canMove;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        canMove = true;
        // let the gameObject fall down
        //gameObject.transform.position = new Vector3(0, 5, 0);
    }

    void Update()
    {
        if (canMove)
        {


            if (controller.isGrounded)
            {
                // We are grounded, so recalculate
                // move direction directly from axes

                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
                moveDirection.Normalize();
                moveDirection = Follower.TransformDirection(moveDirection);
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    moveDirection = moveDirection * runspeed;
                }
                else
                {
                    moveDirection = moveDirection * speed;
                }
                if (Input.GetButton("Jump"))
                {
                    moveDirection.y = jumpSpeed;
                }
            }

            // Apply gravity
            moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

            // Move the controller
            controller.Move(moveDirection * Time.deltaTime);
            Vector3 temp = new Vector3(moveDirection.x, 0, moveDirection.z);
            anim.SetFloat("Speed", temp.magnitude);
        }
    }
}
