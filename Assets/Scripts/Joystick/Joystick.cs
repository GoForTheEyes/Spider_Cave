using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler  {

    PlayerScript playerScript;

    public void OnPointerDown(PointerEventData data)
    {
        if (gameObject.name == "LeftButton")
        {
            playerScript.SetMoveLeft(true);
        }

        if (gameObject.name == "RightButton")
        {
            playerScript.SetMoveRight(true);
        }

        if (gameObject.name == "JumpButton")
        {
            playerScript.Jump();
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        if (gameObject.name == "LeftButton")
        {
            playerScript.SetMoveLeft(false);
        }

        if (gameObject.name == "RightButton")
        {
            playerScript.SetMoveRight(false);
        }
    }


    // Use this for initialization
    void Start () {
        playerScript = FindObjectOfType<PlayerScript>();
	}
	
}
