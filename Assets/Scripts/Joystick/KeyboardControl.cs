using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControl : MonoBehaviour {

    PlayerScript playerScript;

    // Use this for initialization
    void Start () {
        playerScript = FindObjectOfType<PlayerScript>();
    }
	
	// Update is called once per frame
	void Update () {
        PlayerWalkKeyboard();
    }

    private void PlayerWalkKeyboard()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if (h > 0) //moving to the right
        {
            playerScript.SetMoveRight(true);
            playerScript.SetMoveLeft(false);
        }
        else if (h < 0) //moving to the left
        {
            playerScript.SetMoveRight(false);
            playerScript.SetMoveLeft(true);
        }
        else if (h == 0)
        {
            playerScript.SetMoveRight(false);
            playerScript.SetMoveLeft(false);
        }


        if (Input.GetKey(KeyCode.Space))
        {
            playerScript.SetJump(true);
        } else
        {
            playerScript.SetJump(false);
        }
    }

}
