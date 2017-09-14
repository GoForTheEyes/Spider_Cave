using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public static Door instance;

    private Animator anim;
    private BoxCollider2D box;

    [HideInInspector]
    public int collectablesCount;

    private void Awake()
    {
        MakeInstance();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }


    void MakeInstance()
    {
        if (instance == null) instance = this;
    }

    IEnumerator OpenDoor()
    {
        anim.SetBool("Open", true);
        yield return new WaitForSeconds(.7f);
        box.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Player")
        {
            Debug.Log("Game Finished");
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
