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
        //if left click is pressed, Attack
        if (Input.GetMouseButtonDown(0))
            anim.SetBool("Isattacking", true);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            print("Dodge");
            anim.SetBool("Dodge", true);
            Dodge();
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
        
        //Link to an attack script
        GameObject player = GameObject.Find("Player");
        charAttacking.attacking = true;
        //charAttacking.Attacking();
        
        
    }
    
    public void AttackStop()
    {
        //Puts the animation back to the movement or idle one, gives back movement, sets attacking to false.
        anim.SetBool("Isattacking", false);
        
        
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
    }
}