using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform player;
    private float minY = 0f, maxY = 5.3f;
    private float minX = -15f, maxX = 160f;


    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;	
	}
	
	// Update is called once per frame
	void Update () {
		if (player !=null)
        {
            Vector3 temp = transform.position;
            temp.x = Mathf.Clamp(player.position.x, minX, maxX);
            temp.y = Mathf.Clamp(player.position.y, minY, maxY);
            transform.position = temp;
        }
	}
}
