using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script defines which sprite the 'Player" uses and its health.
/// </summary>

public class Player : MonoBehaviour
{
    public GameObject destructionFX;

    public static Player instance;

    public MusicManager music;

    //shake
    private shake shake;

    //game over main menu
    public bool playerDied = false;


    private void Awake()
    {
        if (instance == null) 
            instance = this;
    }

    private void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<shake>();
    }

    //method for damage proceccing by 'Player'
    public void GetDamage(int damage)   
    {
        //Destruction2();
        Destruction();
    }    

    public void TakeDamage(int damage)
    {
        Des2();
    }

    //'Player's' destruction procedure
    void Destruction()
    {
        shake.ShakeCamera2();
        Instantiate(destructionFX, transform.position, Quaternion.identity); //generating destruction visual effect and destroying the 'Player' object
        music.PlayerDeath = true;
        Destroy(gameObject);
    }

    void Des2()
    {
        playerDied = true;
        shake.ShakeCamera2();
        Instantiate(destructionFX, transform.position, Quaternion.identity); //generating destruction visual effect and destroying the 'Player' object
        Destroy(gameObject);
    }

/*    void Destruction2()
    {
        shake.ShakeCamera2();
        Instantiate(destructionFX, transform.position, Quaternion.identity); //generating destruction visual effect and destroying the 'Player' object
        playerDied = true;
        Destroy(gameObject);
        music.PlayerDeath = true;
        
    }*/
}

















