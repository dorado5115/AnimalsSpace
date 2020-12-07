using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines the damage and defines whether the projectile belongs to the ‘Enemy’ or to the ‘Player’, whether the projectile is destroyed in the collision, or not and amount of damage.
/// </summary>

public class Projectile : MonoBehaviour {

    [Tooltip("Damage which a projectile deals to another object. Integer")]
    public int damage;

    [Tooltip("Whether the projectile belongs to the ‘Enemy’ or to the ‘Player’")]
    public bool enemyBullet;

    [Tooltip("Whether the projectile is destroyed in the collision, or not")]
    public bool destroyedByCollision;

    //projectile follows player
    private Transform player;
    private Vector2 target;
    public float speed;

    //camerashake
   // private shake shake;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);

        //shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<shake>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            Destruction();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //when a projectile collides with another object
    {
        if (enemyBullet && collision.tag == "Player") //if anoter object is 'player' or 'enemy sending the command of receiving the damage
        {
            Player.instance.GetDamage(damage); 
            if (destroyedByCollision)
                Destruction();
        }
        else if (!enemyBullet && collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().GetDamage(damage);
            //shake.CameraShake();
            if (destroyedByCollision)
                Destruction();
        }
        else if (!enemyBullet && collision.tag == "Boss")
        {
            collision.GetComponent<Boss>().GetDamage(damage);
            if (destroyedByCollision)
                Destruction();
        }
    }

    void Destruction() 
    {
        Destroy(gameObject);
    }
}


