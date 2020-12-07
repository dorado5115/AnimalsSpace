using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //shake when he die


    #region FIELDS
    [Tooltip("Health points in integer")]
    public int health = 0;
    public int maxHealth = 400;

    [Tooltip("VFX prefab generating after destruction")]
    public GameObject destructionVFX;
    public GameObject hitEffect;
    public GameObject Projectile;

    public int shotChance; //probability of 'Enemy's' shooting during tha path
    public float shotTimeMin, shotTimeMax; //max and min time for shooting from the beginning of the path
    #endregion

    private AudioSource audio;

    //laser
  //  public GameObject laser;

    //healthbar
    public HealthBar healthBar;

    //anim
    public Animator anim;

    bool startBool = false;

    private shake shake;

    private MainMenu mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<shake>();

        if (startBool == false)
        { 
            StartCoroutine(start());
        }
        audio = GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>();

        mainMenu = GameObject.FindGameObjectWithTag("canvas").GetComponent<MainMenu>();

        
    }

    // Update is called once per frame
    void Update()
    {
        //Invoke("ActivateShooting", Random.Range(shotTimeMin, shotTimeMax));
    }

    public void GetDamage(int damage)
    {
        health -= damage;           //reducing health for damage value, if health is less than 0, starting destruction procedure

        healthBar.SetHealth(health);

        if (health <= 0)
        {
            Destruction();
            shake.ShakeCamera3();
            mainMenu.Credits();
        }
        else
        {
           Instantiate(hitEffect, transform.position, Quaternion.identity, transform);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player.instance.GetDamage(1);                
        }
    }

    void Destruction()
    {
        Instantiate(destructionVFX, transform.position, Quaternion.identity);
        Instantiate(destructionVFX, transform.position, Quaternion.identity);
        Instantiate(destructionVFX, transform.position, Quaternion.identity);
        Instantiate(destructionVFX, transform.position, Quaternion.identity);
        Instantiate(destructionVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

   /* void ActivateShooting()
    {
        if (Random.value < (float)shotChance / 100)                             //if random value less than shot probability, making a shot
        {
            Instantiate(Projectile, gameObject.transform.position, Quaternion.identity);
        }

    }*/

    public void PlaySound(AudioClip whichSound)
    {
        audio.PlayOneShot(whichSound);
    }

    public void Shake()
    {

        shake.ShakeCamera2();
    }

    IEnumerator start()
    {
        startBool = true;
        yield return new WaitForSeconds(2f);
        anim.SetTrigger("Start");
    }
}
