using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float moveForce = 20f, jumpForce = 500f, maxVelocity = 4f;

    private bool grounded;
    private Rigidbody2D myBody;
    private Animator anim;

    private void Awake()
    {
        Initialize();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        PlayerWalkKeyboard();
    }

    private void Initialize()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void PlayerWalkKeyboard()
    {
        float forceX = 0f;
        float forceY = 0f;
        float velocity = Mathf.Abs(myBody.velocity.x);
        float h = Input.GetAxisRaw("Horizontal");
        
        if (h>0) //moving to the right
        {
            if (velocity < maxVelocity)
            {
                if (grounded)
                {
                    forceX = moveForce;
                }
                else
                {
                    forceX = moveForce*0.3f;
                }
            }
            Vector3 facing = transform.localScale;
            facing.x = 1;
            transform.localScale = facing;
            anim.SetBool("Walk", true);
        }
        else if (h<0) //moving to the left
        {
            if (velocity < maxVelocity)
            {
                if (grounded)
                {
                    forceX = -moveForce;
                }
                else
                {
                    forceX = -moveForce * 0.3f;
                }
            }
            Vector3 facing = transform.localScale;
            facing.x = -1;
            transform.localScale = facing;
            anim.SetBool("Walk", true);
        }
        else if (h==0)
        {
            anim.SetBool("Walk", false);
            //myBody.velocity = Vector3.zero;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                forceY = jumpForce;
            }
        }

        myBody.AddForce(new Vector2(forceX, forceY));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Ground")
        {
            grounded = true;
        }
    }


}
