using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //shake when he die


    #region FIELDS
    [Tooltip("Health points in integer")]
    public int health = 0;
    public int maxHealth = 200;

    [Tooltip("VFX prefab generating after destruction")]
    public GameObject destructionVFX;
    public GameObject hitEffect;

    [HideInInspector] public int shotChance; //probability of 'Enemy's' shooting during tha path
    [HideInInspector] public float shotTimeMin, shotTimeMax; //max and min time for shooting from the beginning of the path
    #endregion

    private AudioSource audio;

    //laser
    public GameObject laser;

    //healthbar
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        //animacion de entrada
        audio = GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ActivateShooting());
    }

    public void GetDamage(int damage)
    {
        health -= damage;           //reducing health for damage value, if health is less than 0, starting destruction procedure

        healthBar.SetHealth(health);

        if (health <= 0)
        {
            Destruction();
        }
        else
        {

        }
           // Instantiate(hitEffect, transform.position, Quaternion.identity, transform);
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
        Destroy(gameObject);
    }

    IEnumerator ActivateShooting()
    {
        yield return new WaitForSeconds(4f);
        laser.SetActive(true);
        //animacion
        yield return new WaitForSeconds(1f);
        laser.SetActive(false);

    }

    public void PlaySound(AudioClip whichSound)
    {
        audio.PlayOneShot(whichSound);
    }
}
