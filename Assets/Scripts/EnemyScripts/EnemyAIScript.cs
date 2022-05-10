using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIScript : MonoBehaviour
{

    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;

    public int damageToDeal = 10;

    public int maxHealth = 30;
    public int currentHealth;

    public bool Aggro = false;
    public CharAttacking charAttacking;

    public HealthBar healthBar;
    public Canvas enemyCanvas;

    public bool walking = false;

    Animator a_animator;

    public ShroomProjSpawner spawner;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        a_animator = gameObject.GetComponent<Animator>();
        a_animator.SetBool("Attack", false);
        
        
        
    }

    // Update is called once per frame
    void Update()
    {

       


        float distance = Vector3.Distance(target.position, transform.position);
        FaceTarget();
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            Aggro = true;
            



            if (distance <= agent.stoppingDistance + 5f)
            {
                //attacks
                Attack();
                //Play attack animation (trigger the attack to on in the animator)
                //At the certain point in the animation, spawn an invisible object that oncollisionenter hurts the player
                //After spawning it, turn it off
                //face target
                FaceTarget();
            }
        }
        
        if (Aggro == true) { agent.SetDestination(target.position); enemyCanvas.enabled = true; lookRadius = 50f; distance = lookRadius;  } 
        

        
        
        if (currentHealth <= 0)
        {
            Aggro = false;
            // GameObject player = GameObject.Find("Player");
            //charAttacking = player.GetComponentInChildren<CharAttacking>();
            // charAttacking.pulledAggro = false;
            enemyCanvas.enabled = false;
            Die();
            
        }
       
        if(currentHealth != maxHealth) 
        { 
            Aggro = true; 
        }

        
    }

    void FaceTarget()
    {
        print("Facing Target");
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void HitByProjectile(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        print("Enemy Was Hit");

        if(currentHealth <= 0)
        {
            Die();
        }

    }
    void Die()
    {
        Aggro = false;
        GameObject player = GameObject.Find("Player");
        charAttacking = player.GetComponentInChildren<CharAttacking>();
        step();
        a_animator.SetBool("Die", true);
        agent.enabled = false;

        enabled = false;
        Aggro = false;
    }



    #region Attacks
    public void Attack()
    {
        
        FaceTarget();
        a_animator.SetBool("Attack", true);
        

    }

    public void FireAttack()
    {
        FMODUnity.RuntimeManager.PlayOneShot("Event:/Interactions/GruntEnemyShoot", transform.position);
        spawner.SpawnAttack();
    }

    public void AttackStop()
    {
        //disable attack obj
        a_animator.SetBool("Attack", false);
        FaceTarget();
    }
    #endregion

    public void step()
    {
        FMODUnity.RuntimeManager.PlayOneShot("Event:/Movement/GruntEnemyMove", transform.position);
    }
}
