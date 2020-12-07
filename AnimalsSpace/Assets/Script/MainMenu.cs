using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int game, thisScene;
    public Animator animLevelLoader;
    public Animator music;

    //instructions
    public GameObject instructionsMenuUI;

    //Boss level
    private int bossLevel;

    // Start is called before the first frame update
    void Start()
    {
        game = SceneManager.GetActiveScene().buildIndex + 1;
        thisScene = SceneManager.GetActiveScene().buildIndex;

        bossLevel = SceneManager.GetActiveScene().buildIndex + 1;
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
        instructionsMenuUI.SetActive(true);
    }

    public void Back()
    {
        instructionsMenuUI.SetActive(false);
    }

    public void BossLevel()
    {
        StartCoroutine(LoadBossLevel());
    }


    IEnumerator Loadlevel(int level)
    {
        animLevelLoader.SetTrigger("Start");
        music.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);
    }

    IEnumerator LoadBossLevel()
    {
        Debug.Log("starting boos level");
        yield return new WaitForSeconds(180f);
        animLevelLoader.SetTrigger("Start");
        music.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(bossLevel);
    }
}
