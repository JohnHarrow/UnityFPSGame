using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 //https://www.youtube.com/watch?v=THnivyG0Mvo&ab_channel=Brackeys
//This script was made by editing the Target script I got from the above tutorial. I originally used the same target script on 
//both the player and the enemies but it makes things easier to have a different script for each one.
public class EnemyStats : MonoBehaviour
{
    /*-------------------- My Code --------------------*/
    public GameObject gm;
    public GameObject playerStats;
    public float health;
    public Animator animator;
    public GameObject zombie;
    /*-------------------- My Code --------------------*/

    void Start()
    {
        /*-------------------- My Code --------------------*/
        //This code gets the health variable that I am increasing each each wave and assigns it to the enemies.
        gm = GameObject.Find("GM");
        WaveSpawner waveSpawner = gm.GetComponent<WaveSpawner>();
        health = waveSpawner.enemyHealth;
        /*-------------------- My Code --------------------*/
    }

    

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            /*-------------------- My Code --------------------*/
            animator.SetBool("isDead", true);
            EnemyAI enemyAI = zombie.GetComponent<EnemyAI>();
            enemyAI.isDead = true;
            Invoke(nameof(Die), 1f);
            /*-------------------- My Code --------------------*/
        }
    }

    void Die()
    {
        Destroy(gameObject);

        /*-------------------- My Code --------------------*/
        playerStats = GameObject.Find("First Person Player");
        PlayerStats stats = playerStats.GetComponent<PlayerStats>();
        stats.points += 100f;
        /*-------------------- My Code --------------------*/
    }
}
