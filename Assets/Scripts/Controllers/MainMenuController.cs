using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {



    public void PlayGame()
    {
        FadeController.instance.ChangeSceneWithFadeEffectString("LevelMenu");
        //SceneManager.LoadScene("LevelMenu");
    }
}
