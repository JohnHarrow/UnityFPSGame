using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//https://www.youtube.com/watch?v=UjkSFoLxesw&ab_channel=Dave%2FGameDevelopment
//I got the base for my AI from this tutorial and changed some things ot fit my game more which include the melee attack rather than a ranged one. The code I have contributed is made clear below.

public class EnemyAI : MonoBehaviour
{

    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    /*-------------------- My Code --------------------*/
    public float attackDamage = 10f;
    public GameObject playerToAttack;
    public GameObject gm;

    //private bool isRunning = false;
    //private bool isAttacking = false;
    public Animator animator;

    public bool isDead = false;
    /*-------------------- My Code --------------------*/


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("First Person Player").transform;
        agent = GetComponent<NavMeshAgent>();

        /*-------------------- My Code --------------------*/
        //Code for increasing enemy movement speed each wave
        gm = GameObject.Find("GM");
        WaveSpawner waveSpawner = gm.GetComponent<WaveSpawner>();
        agent.speed = waveSpawner.enemySpeed;
        /*-------------------- My Code --------------------*/

    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInSightRange && !playerInAttackRange && !isDead) ChasePlayer();
        if (playerInAttackRange && playerInSightRange && !isDead) AttackPlayer();

    }

    private void ChasePlayer()
    {
        /*-------------------- My Code --------------------*/
        animator.SetBool("isRunning", true);
        animator.SetBool("isAttacking", false);
        /*-------------------- My Code --------------------*/
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(player.position);
        

        /*-------------------- My Code --------------------*/

        if (!alreadyAttacked)
        {
            FindObjectOfType<AudioManager>().Play("EnemyAttack");
            animator.SetBool("isRunning", false);
            animator.SetBool("isAttacking", true);
            playerToAttack = GameObject.Find("First Person Player");
            PlayerStats stats = playerToAttack.GetComponent<PlayerStats>();
            stats.TakeDamage(attackDamage);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
        /*-------------------- My Code --------------------*/
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
