using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelController : MonoBehaviour {

    public Toggle keyboardToggle, touchToggle;

    public const string INPUT = "Input_Control";
    //const string LEVEL1 = "Level1";
    public const string LEVEL2_ACCESS = "Level2";

    private void Awake()
    {
        if (!PlayerPrefs.HasKey(INPUT))
        {
            keyboardToggle.isOn = true;
            touchToggle.isOn = false;
            SetInput("keyboard");
        } else
        {
            if (PlayerPrefs.GetString(INPUT) =="Keyboard")
            {
                keyboardToggle.isOn = true;
                touchToggle.isOn = false;
            }
            else if (PlayerPrefs.GetString(INPUT) == "touch")
            {
                keyboardToggle.isOn = false;
                touchToggle.isOn = true;
            }
        }
    }


    public void PlayGame(int lvl)
    {
        if (lvl == 1) {
            SetControls();
            FadeController.instance.ChangeSceneWithFadeEffectString("Gameplay_" + lvl);
            //SceneManager.LoadScene("Gameplay_" + lvl);
        }
        else if (lvl ==2)
        {
            if (PlayerPrefs.HasKey(LEVEL2_ACCESS) && PlayerPrefs.GetInt(LEVEL2_ACCESS) == 1)
            {
                SetControls();
                FadeController.instance.ChangeSceneWithFadeEffectString("Gameplay_" + lvl);
                //SceneManager.LoadScene("Gameplay_" + lvl);
            }
        }
    }

    private void SetControls()
    {
        if (keyboardToggle.isOn)
        {
            SetInput("keyboard");
        }
        else if (touchToggle.isOn)
        {
            SetInput("touch");
        }
    }

    public void BackToMenu()
    {
        FadeController.instance.ChangeSceneWithFadeEffectString("MainMenu");
        //SceneManager.LoadScene("MainMenu");
    }

    public static int GetLevel2Access()
    {
        return PlayerPrefs.GetInt(LEVEL2_ACCESS);
    }

    public static void SetLevel2Access(int value)
    {
        PlayerPrefs.SetInt(LEVEL2_ACCESS, value);
    }

    public static void SetInput(string inputControl)
    {
        PlayerPrefs.SetString(INPUT, inputControl);
    }

    public static string GetInput()
    {
        return PlayerPrefs.GetString(INPUT);
    }

}
