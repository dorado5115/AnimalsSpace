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

    //game over
    private Player player;
    private MusicBoss boss;


    int nextlevel;

    // Start is called before the first frame update
    void Start()
    {


        game = SceneManager.GetActiveScene().buildIndex + 1;
        thisScene = SceneManager.GetActiveScene().buildIndex;

        bossLevel = SceneManager.GetActiveScene().buildIndex + 1;

        nextlevel = SceneManager.GetActiveScene().buildIndex + 1;

        boss = GameObject.FindGameObjectWithTag("music").GetComponent<MusicBoss>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        if(player.playerDied == true)
        {
            Die();
        }
        else
        {

        }
    }

    public void PlayGame()
    {
        StartCoroutine(Loadlevel(nextlevel));
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

    public void Die()
    {
        boss.BossScene();
    }

    public void Credits()
    {
        StartCoroutine(Loadlevel(bossLevel));
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
