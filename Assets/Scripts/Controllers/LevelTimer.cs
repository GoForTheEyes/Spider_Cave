using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{

    private Slider slider;

    private GameObject player;

    private GameplayController gameplayController;

    public float time = 45f;

    private float timeBurn = 0.5f;

    private void Awake()
    {
        GetReferences();
        gameplayController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameplayController>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!player) return;

        if (time > 0)
        {
            time -= timeBurn * Time.deltaTime;
            slider.value = time;
        }
        else //Player died asphyxiated
        {
            gameplayController.PlayerDied();
        }
    }

    void GetReferences()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        slider = GameObject.Find("Time Slider").GetComponent<Slider>();
        slider.minValue = 0f;
        slider.maxValue = time;
        slider.value = slider.maxValue;
    }

    public void IncreaseSlider(float increase)
    {
        time = Mathf.Min(slider.maxValue, time + increase);
    }
}


