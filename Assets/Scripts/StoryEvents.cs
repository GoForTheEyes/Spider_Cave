using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryEvents : MonoBehaviour {

    public BoxCollider2D box;
    private Door door;
    private bool eventTriggered = false;

    // Use this for initialization
    void Start () {
        door = GetComponent<Door>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && door.doorOpen == false && eventTriggered == false)
        {
            eventTriggered = true;
            collision.gameObject.GetComponent<PlayerStoryEvents>().StoryEvent1();
            
        }
    }

}
