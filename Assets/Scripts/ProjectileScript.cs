using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    // Start is called before the first frame update
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
        
        if(other.gameObject.tag == "Ground")
        {
            FMODUnity.RuntimeManager.PlayOneShot("Event:/Impact/PlayerProjectile", transform.position);
            print("attack hit ground");
            Destroy(transform.gameObject);
        }

        if(other.gameObject.tag == "Enemy")
        {
            FMODUnity.RuntimeManager.PlayOneShot("Event:/Impact/PlayerProjectile", transform.position);
            Destroy(transform.gameObject);
            other.gameObject.GetComponent<EnemyAIScript>().HitByProjectile(10);
            

        }
        if (other.gameObject.tag == "EnemyBoss")
        {
            FMODUnity.RuntimeManager.PlayOneShot("Event:/Impact/PlayerProjectile", transform.position);
            Destroy(transform.gameObject);
            
            other.gameObject.GetComponent<EnemyScriptBoss>().HitByProjectile(10);
            
        }

    }

    IEnumerator WaitForDestroy()
    {
        print("WaitForDestroy started");
        yield return new WaitForSeconds(5);
        FMODUnity.RuntimeManager.PlayOneShot("Event:/Impact/PlayerProjectile", transform.position);
        Destroy(transform.gameObject);
    }
}
