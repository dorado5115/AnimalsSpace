using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip deathSound;
    public AudioSource audiosource;
    public bool PlayerDeath = false;

    //GAMEOVER
    public GameObject gameOverMenu;


    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.loop = true;
        audiosource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerDeath == true)
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
