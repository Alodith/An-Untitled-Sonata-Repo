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
    
    public float health;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
        
       
    }

    // Update is called once per frame
    void Update()
    {
        print("Update");
     

     if(currentHealth <= 0)
        {
            print("Dead");
            Die();

        }   



     if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
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

    public void Heal(int amount)
    {

        print("healing");
        currentHealth += amount;

        healthBar.SetHealth(currentHealth);
    }
}
