using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomAnimTest : MonoBehaviour
{

    public Animator a_animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackSpawn()
    {
        //enable attack object
       // FaceTarget();
    }

    public void AttackStop()
    {
        //disable attack obj
        a_animator.SetBool("Attack", false);
        
    }

}
