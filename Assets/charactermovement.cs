//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class charactermovement : MonoBehaviour {

    public bool isGrounded;
    private float speed;
    public float rotSpeed;
    public float jumpHeight;
    private float w_speed = 0.02f;
    private float rot_speed = 3.0f;
    private bool crouching=false;
    Rigidbody rp;
    Animator anim;
/*
    void movementControl(string state)
    {
        switch (state)
        {
            case "WalkingForward":

                anim.SetBool("isWalkingForward", true);
                anim.SetBool("isWalkingBackward", false);
                anim.SetBool("isIdle", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("Stand", false);
                break;
            case "WalkingBackward":
                anim.SetBool("isWalkingForward", false);
                anim.SetBool("isWalkingBackward", true);
                anim.SetBool("isIdle", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("Stand", false);
                break;
            case "Idle":

                anim.SetBool("isWalkingForward", false);
                anim.SetBool("isWalkingBackward", false);
                anim.SetBool("isIdle", true);
                anim.SetBool("isRunning", false);
                anim.SetBool("isCrouch", false);
                break;

            case "Running":

                anim.SetBool("isWalkingForward", false);
                anim.SetBool("isWalkingBackward", false);
                anim.SetBool("isIdle", false);
                anim.SetBool("isRunning", true);

                break;
            case "crouch":
                anim.SetBool("isWalkingForward", false);
                anim.SetBool("isWalkingBackward", false);
                anim.SetBool("isIdle", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("isCrouch", true);
                anim.SetBool("crouchWalk", false);
                break;
            case "walkingCrouch":
                anim.SetBool("isWalkingForward", false);
                anim.SetBool("isWalkingBackward", false);
                anim.SetBool("isIdle", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("isCrouch", false);
                anim.SetBool("crouchWalk", true);
                break;

        }
    }
    */
    // Use this for initialization
    void Start()
    {
        rp = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        isGrounded = true;
        GameObject go = GameObject.Find("wibble");
        //Debug.Log(go.name);

    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {   //moving forward and backward
            
            if (Input.GetKey(KeyCode.W) || Input.GetKey("up"))
            {
                speed = w_speed;

                anim.SetBool("iswalking", true);

            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey("down"))
            {
                speed = w_speed;
                anim.SetBool("iswalking", true);

            }
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = w_speed;
                anim.SetBool("iswalking", true);

                this.transform.Translate(Vector3.forward * 0.05f);
            }
           
           else
            {
                anim.SetBool("iswalking", false);

                anim.SetBool("isidle", true);
            }

            //moving right and left
            if (Input.GetKey(KeyCode.A) || Input.GetKey("left"))
            {
                rotSpeed = rot_speed;
            }

            else if (Input.GetKey(KeyCode.D) || Input.GetKey("right"))
            {
                rotSpeed = rot_speed;
            }
            else
            {
                rotSpeed = 0;
            }
        }
        var z = Input.GetAxis("Vertical") * speed;
        var y = Input.GetAxis("Horizontal") * rotSpeed;
        transform.Translate(0, 0, z);
        transform.Rotate(0, y, 0);

        //jummping function 
        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            anim.SetTrigger("isJumping");
            rp.AddForce(0, jumpHeight * Time.deltaTime, 0);
            //isGrounded = false;
        }
    }


}
