using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderJumper : MonoBehaviour {

    public float forceY = 300f;

    private Rigidbody2D myBody;
    private Animator anim;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(2, 7));
        forceY = Random.Range(250f, 550f);
        myBody.AddForce(new Vector2(0, forceY));
        anim.SetBool("Attack", true);
        yield return new WaitForSeconds(.7f);
        StartCoroutine(Attack());
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(Attack());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            anim.SetBool("Attack", false);
        }

        if (collision.tag == "Player")
        {
            Destroy(collision.gameObject);
        }

    }

}
