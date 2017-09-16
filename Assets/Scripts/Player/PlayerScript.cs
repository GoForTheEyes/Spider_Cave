using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    public float moveForce = 35f, jumpSpeed = 8f, maxVelocity = 4.5f;
    private bool movingLeft, movingRight, jump;
    private float distanceToGround;

    private bool grounded;
    private Rigidbody2D myBody;
    private Animator anim;
    private GameObject playerCanvas;
    private Text playerText;
    private BoxCollider2D myCollider;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerCanvas = transform.GetChild(0).gameObject;
        playerText = GetComponentInChildren<Text>();
        myCollider = GetComponent<BoxCollider2D>();

    }

    private void Start()
    {
        playerCanvas.SetActive(false);
        movingLeft = false;
        movingRight = false;
        jump = false;
        distanceToGround = myCollider.bounds.extents.y;
    }

    private void FixedUpdate()
    {
        if (movingLeft)
        {
            MoveLeft();
        }
        else if (movingRight)
        {
            MoveRight();
        }
        else
        {
            NoMoveInput();
        }
        if (jump)
        {
            Jump();
        }
        grounded = IsGrounded();
    }

    public void SetMoveRight(bool value)
    {
        movingRight = value;
    }

    public void SetMoveLeft(bool value)
    {
        movingLeft = value;
    }

    public void SetJump(bool value)
    {
        jump = value;
    }

    public void MoveRight()
    {
        float forceX = 0f;
        float velocity = Mathf.Abs(myBody.velocity.x);
        if (velocity < maxVelocity)
        {
            if (grounded)
            {
                forceX = moveForce;
            }
            else
            {
                forceX = moveForce * 0.3f;
            }
        }
        Vector3 facing = transform.localScale;
        facing.x = 1;
        transform.localScale = facing;
        anim.SetBool("Walk", true);
        myBody.AddForce(new Vector2(forceX, 0f));
    }

    public void MoveLeft()
    {
        float forceX = 0f;
        float velocity = Mathf.Abs(myBody.velocity.x);
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
        myBody.AddForce(new Vector2(forceX, 0f));
    }

    public void NoMoveInput()
    {
        float velocity = Mathf.Abs(myBody.velocity.x);
        if (velocity <= 1f)
        {
            anim.SetBool("Walk", false);
        }
    }

    public void Jump()
    {
        Vector3 currentVelocity = myBody.velocity;
        float velocityY = Mathf.Abs(currentVelocity.y);
        if (grounded && velocityY<1f)
        {
            currentVelocity.y = jumpSpeed;
        } 
        myBody.velocity = currentVelocity;    
    }

    

    public void BouncePlayerWithBouncy (float force, float max_force)
    {
        grounded = false;
        float jumpBounce = force + Mathf.Min(-myBody.velocity.y * force / 3, max_force - force);
        myBody.AddForce(new Vector2(0f, jumpBounce));
    }




    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, distanceToGround, LayerMask.GetMask("Ground"));
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Ground")
    //    {
    //        grounded = false;
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Ground")
    //    {
    //        grounded = true;
    //    }
    //}




}
