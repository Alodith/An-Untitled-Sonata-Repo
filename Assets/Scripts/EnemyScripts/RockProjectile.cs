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
        StartCoroutine(WaitForDestroy());


    }

    // Update is called once per frame
    void Update()
    {
        //if object collides with terrain, destroy the object
    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Ground")
        {
            FMODUnity.RuntimeManager.PlayOneShot("Event:/Interactions/BossRockImpact", transform.position);
            print("attack hit ground");
            //camerashake
            Destroy(transform.gameObject);
        }
        if(other.gameObject.tag == "Player")
        {
            FMODUnity.RuntimeManager.PlayOneShot("Event:/Interactions/BossRockImpact", transform.position);
            //camerashake
            Destroy(transform.gameObject);

            other.gameObject.GetComponent<PlayerBasic>().TakeDamage(25);
        }
        

    }

    IEnumerator WaitForDestroy()
    {
        print("BossWaitForDestroy started");
        yield return new WaitForSeconds(5);
        FMODUnity.RuntimeManager.PlayOneShot("Event:/Interactions/BossRockImpact", transform.position);
        Destroy(transform.gameObject);
    }
}
