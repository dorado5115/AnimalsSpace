using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBoss : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip deathSound;

    public bool PlayerDeath = false;
    //GAMEOVER
    public GameObject gameOverMenu;

    //player
    private PlayerShooting playerShooting;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.loop = true;

        playerShooting = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        playerShooting.weaponPower = 0;

        if (PlayerDeath == true)
        {
            PlayerDeath = false;
            audiosource.Stop();
            audiosource.loop = false;
            audiosource.PlayOneShot(deathSound, 0.3f);
            StartCoroutine(Stop());
        }
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(1.2F);
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
