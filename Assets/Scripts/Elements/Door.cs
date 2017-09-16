using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public static Door instance;
    public BoxCollider2D box;

    private Animator anim;

    [HideInInspector]
    public int collectablesCount;
    [HideInInspector]
    public bool doorOpen;

    private void Awake()
    {
        MakeInstance();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        doorOpen = false;
    }


    void MakeInstance()
    {
        if (instance == null) instance = this;
    }

    IEnumerator OpenDoor()
    {
        anim.SetBool("Open", true);
        yield return new WaitForSeconds(.7f);
        doorOpen = true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Player" && doorOpen==true)
        {
            GameplayController.instance.PlayerWinsLevel();
        }
    }

    public void DecrementCollectables()
    {
        collectablesCount--;
        if (collectablesCount == 0)
        {
            StartCoroutine(OpenDoor());
        }
    }


}
