using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamonds : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (Door.instance != null) {
            Door.instance.collectablesCount++;
        }
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            if (Door.instance != null)
            {
                Door.instance.DecrementCollectables();
            }
            Destroy(gameObject);
        }
    }

}
