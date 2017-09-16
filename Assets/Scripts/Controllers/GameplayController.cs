using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {

    public static GameplayController instance;

    public GameObject pausePanel;
    public Button resumeButton;
    public Button pauseButton;
    public Text panelText;

    private Joystick[] joystickControl;
    private KeyboardControl keyboardControl;
    private PlayerStoryEvents playerStory;

    private void Awake()
    {
        MakeInstance();
        playerStory = FindObjectOfType<PlayerStoryEvents>();
        Initialize();
        InitialAnimation();
    }

    void MakeInstance()
    {
        if (instance == null) instance = this;
    }

    public void InitialAnimation()
    {
        if (SceneManager.GetActiveScene().name == "Gameplay_1")
        {
            playerStory.InitialAnimation();
        }
        
    }


    public void Initialize()
    {
        pausePanel.SetActive(false);
        pauseButton.gameObject.SetActive(true);

        //Controls
        joystickControl = FindObjectsOfType<Joystick>();
        keyboardControl = FindObjectOfType<KeyboardControl>();

        bool touchControls = LevelController.GetInput() == "touch";
        keyboardControl.gameObject.SetActive(!touchControls);
        foreach (var joy in joystickControl)
        {
            //use transform.parent to access the parent in hierarchy
            joy.transform.parent.gameObject.SetActive(touchControls);
        }
    }


    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        panelText.text = "Game Paused";
        resumeButton.onClick.RemoveAllListeners();
        resumeButton.onClick.AddListener(() => ResumeGame());
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        FadeController.instance.ChangeSceneWithFadeEffectString("MainMenu");
        //SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        FadeController.instance.ChangeSceneWithFadeEffectInt(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayerDied()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        panelText.text = "Game Over";
        resumeButton.onClick.RemoveAllListeners();
        resumeButton.onClick.AddListener(() => RestartGame());
    }

    public void PlayerWinsLevel()
    {
        int maxLevelsInGame = 2;
        if (SceneManager.GetActiveScene().buildIndex < maxLevelsInGame)
        {
            if (!PlayerPrefs.HasKey(LevelController.LEVEL2_ACCESS))
            {
                PlayerPrefs.SetInt(LevelController.LEVEL2_ACCESS, 1);
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else
        {
            playerStory.EndGame();
        }
    }

}
