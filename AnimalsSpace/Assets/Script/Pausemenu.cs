using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausemenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
   // public GameObject pauseMenuUi;

    //music manager
   // public MusicManager music;

    //music boss
   // private MusicBoss boss;

    // Update is called once per frame

    private void Start()
    {
        /*boss = GameObject.FindGameObjectWithTag("music").GetComponent<MusicBoss>();*/
    }
    void Update()
    {
        /*if(boss.gameOverMenu == false && Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPaused)
            {
                Time.timeScale = 1f;
                Resume();
            }
            else
            {
                Time.timeScale = 0f;
                BossPause();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
            {
                if (GameIsPaused)
                {
                    Time.timeScale = 1f;
                    Resume();
                }
                else
                {
                    Time.timeScale = 0f;
                    Pause();
                }
            }
        }*/
        
    }

    /*public void Resume()
    {
        music.audiosource.Play();
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }*/
    /*public void Pause()
    {
        if(music == null)
        {

        }
        else
        {
            music.audiosource.Pause();
            pauseMenuUi.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
    }

    public void BossPause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("quitt");
        Application.Quit();
    }*/

}
