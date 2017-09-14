using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShooter : MonoBehaviour {

#pragma warning disable 0649
    [SerializeField]
    private GameObject bullet;
#pragma warning restore 0649

    // Use this for initialization
    void Start () {
        StartCoroutine(Attack());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(2, 7));
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.transform.parent = gameObject.transform;
        StartCoroutine(Attack());
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }

}
