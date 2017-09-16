using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour {

    public static FadeController instance;
    GraphicRaycaster raycaster;
    Animator fadePanel;
    private bool levelready;

	// Use this for initialization
	void Start () {
        MakeSingleton();
        raycaster = GetComponent<GraphicRaycaster>();
        raycaster.enabled = false;
        fadePanel = GetComponentInChildren<Animator>();
	}
	
    void MakeSingleton()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelChange;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelChange;
    }

    private void OnLevelChange(Scene scene, LoadSceneMode mode)
    {
        levelready = true;
    }

    public void ChangeSceneWithFadeEffectString(string sceneName)
    {
        StartCoroutine(ChangingSceneString(sceneName));
    }


    IEnumerator ChangingSceneString(string sceneName)
    {
        Time.timeScale = 0f;
        levelready = false;
        raycaster.enabled = true;
        fadePanel.Play("FadeOut");
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(sceneName);
        while (!levelready)
        {
            yield return new WaitForSecondsRealtime(0.1f);
        }
        Time.timeScale = 0f;
        fadePanel.Play("FadeIn");
        yield return new WaitForSecondsRealtime(1f);
        fadePanel.Play("Idle");
        raycaster.enabled = false;
        Time.timeScale = 1f;

    }

    public void ChangeSceneWithFadeEffectInt(int sceneNum)
    {
        StartCoroutine(ChangingSceneInt(sceneNum));
    }

    IEnumerator ChangingSceneInt(int sceneNum)
    {
        Time.timeScale = 0f;
        levelready = false;
        raycaster.enabled = true;
        fadePanel.Play("FadeOut");
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(sceneNum);
        while (!levelready)
        {
            yield return new WaitForSecondsRealtime(0.1f);
        }
        Time.timeScale = 0f;
        fadePanel.Play("FadeIn");
        yield return new WaitForSecondsRealtime(1f);
        fadePanel.Play("Idle");
        raycaster.enabled = false;
        Time.timeScale = 1f;

    }

}
