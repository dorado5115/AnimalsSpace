using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    [Tooltip("Damage which a projectile deals to another object. Integer")]
    public int damage;


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player.instance.GetDamage(damage);
            
        }
    }
}
