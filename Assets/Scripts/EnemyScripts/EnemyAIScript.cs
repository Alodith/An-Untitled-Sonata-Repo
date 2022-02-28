using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIScript : MonoBehaviour
{

    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;

    public int maxHealth = 30;
    public int currentHealth;

    

    Animator a_animator;



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
            if (distance <= agent.stoppingDistance)
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
        if (currentHealth <= 0)
        {
            Die();
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
        print("Enemy Was Hit");

        if(currentHealth <= 0)
        {
            Die();
        }

    }
    void Die()
    {
        
        a_animator.SetBool("Die", true);
        agent.enabled = false;

        enabled = false;

    }
    #region Attacks
    public void Attack()
    {
        FaceTarget();
        a_animator.SetBool("Attack", true);
    }
    public void AttackSpawn()
    {
        //enable attack object
        FaceTarget();
    }

    public void AttackStop()
    {
        //disable attack obj
        a_animator.SetBool("Attack", false);
        FaceTarget();
    }
    #endregion
}
