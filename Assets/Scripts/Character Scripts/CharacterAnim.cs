using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    #region Gameobjects
    public Animator anim;
    public AudioSource attackAudio1;
    public CharAttacking charAttacking;
    public ThirdPersonMovement tPM;
    public GameObject attackPen;
    public GameObject healPen;

    #endregion

    #region Bools
    public bool isattacking1 = false;

    void Start()
    {
        
    }
    #endregion
    // Update is called once per frame
    void Update()
    {
        #region attackifs
        //if left click is pressed, Attack
       // if (Input.GetMouseButtonDown(0))
           // anim.SetBool("Isattacking", true);

        if(Input.GetMouseButtonDown(0) && (attackPen.activeSelf == true))
        {
            anim.SetBool("Isattacking", true);
        }

        if(Input.GetMouseButtonDown(0) && (healPen.activeSelf == true))
        {
            anim.SetBool("IsHealing", true);
        }
        #endregion

        if(Input.GetKeyDown(KeyCode.Space))
        {
            print("Dodge");
            anim.SetBool("Dodge", true);
            
        }
    }

    void AttackSlowDown()
    {
        //Makes character immobile on attack
        tPM.speed = 0f;
    }
    void Attack()
    {        
        //Attack animation trigger
        isattacking1 = true;
        FMODUnity.RuntimeManager.PlayOneShot("Event:/Interactions/PlayerAttackShoot", transform.position);
        //Link to an attack script
        GameObject player = GameObject.Find("Player");
        charAttacking.attacking = true;
        //charAttacking.Attacking();
        
        
    }

    void Heal()
    {
        //heal
        GameObject player = GameObject.Find("Player");
        charAttacking.healing = true;
        FMODUnity.RuntimeManager.PlayOneShot("Event:/Interactions/PlayerHealShoot", transform.position);
    }
    
    public void AttackStop()
    {
        //Puts the animation back to the movement or idle one, gives back movement, sets attacking to false.
        anim.SetBool("Isattacking", false);
        
        
        tPM.speed = 6f;
    }

    public void HealStop()
    {
        anim.SetBool("IsHealing", false);
        tPM.speed = 6f;
        
    }

    void Dodge()
    {
        tPM.speed = 9f;
    }

    public void EndDodge()
    {
        //dodge is false
        anim.SetBool("Dodge", false);
        //change speed back
        tPM.speed = 6f;
    }


    public void StepSound()
    {
        //Play Step Here
        FMODUnity.RuntimeManager.PlayOneShot("Event:/Movement/PlayerMove", transform.position);
    }

    public void DodgeSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("Event:/Impact/Playerdodge", transform.position);
        
    }
}