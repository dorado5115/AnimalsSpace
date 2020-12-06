﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int game;
    public Animator animLevelLoader;

    // Start is called before the first frame update
    void Start()
    {
        game = SceneManager.GetActiveScene().buildIndex + 1;
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

    IEnumerator Loadlevel(int level)
    {
        animLevelLoader.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);
    }
}
