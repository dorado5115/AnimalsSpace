﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int game, thisScene;
    public Animator animLevelLoader;
    public Animator music;

    // Start is called before the first frame update
    void Start()
    {
        game = SceneManager.GetActiveScene().buildIndex + 1;
        thisScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void PlayGame()
    {
        StartCoroutine(Loadlevel(game));
    }

    public void QuitGame()
    {
        Debug.Log("quitt");
        Application.Quit();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(thisScene);
        score.scoreValue = 00;
        Time.timeScale = 1f;
    }

    public void InstructionsUI()
    {

    }


    IEnumerator Loadlevel(int level)
    {
        animLevelLoader.SetTrigger("Start");
        music.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);
    }
}
