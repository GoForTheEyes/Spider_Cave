using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirTimer : MonoBehaviour {

    private Slider slider;

    private GameObject player;

    private GameplayController gameplayController;

    public float air = 45f; 

    private float airBurn = 0.5f;

    private void Awake()
    {
        GetReferences();
        gameplayController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameplayController>();
    }


	// Update is called once per frame
	void Update () {
        if (!player) return;

        if (air > 0)
        {
            air -= airBurn * Time.deltaTime;
            slider.value = air;
        } else //Player died asphyxiated
        {
            gameplayController.PlayerDied();
        }
	}

    void GetReferences()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        slider = GameObject.Find("Air Slider").GetComponent<Slider>();
        slider.minValue = 0f;
        slider.maxValue = air;
        slider.value = slider.maxValue;
    }

    public void IncreaseSlider(float increase)
    {
        air = Mathf.Min(slider.maxValue, air + increase);
    }
}
