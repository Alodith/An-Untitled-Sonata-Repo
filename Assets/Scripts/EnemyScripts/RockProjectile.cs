using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockProjectile : MonoBehaviour
{
    void Awake()
    {
        //Unparent
        transform.parent = null;
        //Start coroutine that destroys the object after 5 seconds
        //StartCoroutine(WaitForDestroy());


    }

    // Update is called once per frame
    void Update()
    {
        //if object collides with terrain, destroy the object
    }

    void OnCollisionEnter(Collision other)
    {

        //if (other.gameObject.tag == "Ground")
        //{
            //print("attack hit ground");
           // Destroy(transform.gameObject);
      //  }

        

    }

    //IEnumerator WaitForDestroy()
   // {
        //print("WaitForDestroy started");
       // yield return new WaitForSeconds(5);
       // Destroy(transform.gameObject);
    //}
}
