using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasic : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Animator anim;
    public ThirdPersonMovement tpm;
    public GameObject DeathScreen;


    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
     if(currentHealth <= 0)
        {
            Die();
        }   
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    public void Die()
    {
        anim.SetBool("Dead", true);
        tpm.enabled = false;
        //enable death screen
        DeathScreen.SetActive(true);
    }
}
