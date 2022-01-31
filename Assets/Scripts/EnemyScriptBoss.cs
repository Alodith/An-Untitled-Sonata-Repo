using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScriptBoss : MonoBehaviour
{

    
    public float lookRadius = 10f;
    Transform player;
    NavMeshAgent agent;

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public bool BossIsDead = false;
    Animator a_animator;

    public HealthBar healthBar;
    public int maxHealth = 100;
    public int currentHealth;

    NavMeshAgent navMesh;

    public bool enemyMove = false;

    public GameObject encounterWalls;

    #region attackscriptstuff
    public bool attacking = false;
    public GolemBossSpawner spawner;
    public MusicManager mM;
    public AudioSource attackMusicAudio;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        //ensuring the enemy starts with max health
        currentHealth = maxHealth;
        //Set the player as the current player in the scene
        player = PlayerManager.instance.player.transform;
        //set the agent to the navmeshagent on the enemy
        agent = GetComponent<NavMeshAgent>();

        a_animator = gameObject.GetComponent<Animator>();
        navMesh = gameObject.GetComponent<NavMeshAgent>();
        a_animator.SetFloat("Vertical", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        
        if (distance <= lookRadius)
        {
            agent.SetDestination(player.position);
            enemyMove = true;
            if (distance <= agent.stoppingDistance)
            {
                enemyMove = false;
                //attack
                AttackBuild();
                //face target
                FaceTarget();
            }
            
        }
        if(distance >= lookRadius)
        {
            enemyMove = false;
        }


        if (enemyMove == true)
        {
            //set anim
            a_animator.SetFloat("Vertical", 1f);
        }

        if (enemyMove == false)
        {
            //set anim
            a_animator.SetFloat("Vertical", 0);
        }
    }


    void FaceTarget()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }


    #region attackingstuff
    public void HitByProjectile(int damage)
    {
        
        print("Enemy Was Hit");
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth == 0)
        {
            Destroy(encounterWalls);
            print("WallDestroyed");
            //get rid of health bar too
            Die();
            
            
        }
        
    }

    public void AttackBuild()
    {
        print("enemy attack building");
        a_animator.SetBool("Attacking", true);
    }
    public void AttackBuildFinish()
    {
        a_animator.SetBool("Attacking", false);
    }
    public void Attack()
    {
        print("enemy attacks");
        //spawn rock
        spawner.SpawnAttack();
        //fire rock 
    }
    public void Die()
    {
        print("Enemy Dead");
        navMesh.enabled = false;       
        a_animator.SetBool("deadBoss", true);
        
        enabled = false;
    }
    #endregion
}
