using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAndAir : MonoBehaviour {

#pragma warning disable 0649
    [SerializeField]
    private int CollectableType, increase = 15;
#pragma warning restore 0649

    //CollectableType = 0 -> Air
    //CollectableType = 1 -> Time

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (CollectableType == 0) 
            {
                GameObject.Find("GameplayController").GetComponent<AirTimer>().IncreaseSlider(increase);
            }
            else if (CollectableType == 1)
            {
                GameObject.Find("GameplayController").GetComponent<LevelTimer>().IncreaseSlider(increase);
            }
            Destroy(gameObject);
        }
    }
}
