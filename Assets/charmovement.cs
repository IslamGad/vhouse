using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charmovement : MonoBehaviour {
    Rigidbody rp;
    Animator anim;
    private float speed;
    public float rotSpeed;
    public float w_speed;
    private float rot_speed = 5.0f;
    // Use this for initialization
    void Start () {
        rp = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W) || Input.GetKey("up"))
        {
            speed = w_speed;
            anim.SetBool("iswalking", true);
            anim.SetBool("isidle", false);

        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey("down"))
        {
            speed = w_speed;
            anim.SetBool("iswalking", true);
            anim.SetBool("isidle", false);
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
    
        var z = Input.GetAxis("Vertical") * speed;
        var y = Input.GetAxis("Horizontal") * rotSpeed;
        transform.Translate(0, 0, z);
        transform.Rotate(0, y, 0);
	}
}
