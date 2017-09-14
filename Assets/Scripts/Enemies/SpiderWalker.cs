using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWalker : MonoBehaviour {

#pragma warning disable 0649
    [SerializeField]
    private Transform startPos, endPos;
#pragma warning restore 0649

    private bool grounded;

    public float speed = 1f;

    private Rigidbody2D myBody;


    // Use this for initialization
    void Awake () {
        myBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

    }

    void ChangeDirection()
    {
        grounded = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("Ground"));

        //not on the ground
        if (!grounded)
        {
            Vector3 temp = transform.localScale;
            transform.localScale = new Vector3(-temp.x, temp.y, temp.z);
        }
    }


    void FixedUpdate () {
        Move();
        ChangeDirection();
	}

    private void Move()
    {
        myBody.velocity = new Vector2(transform.localScale.x, 0) * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }

}
