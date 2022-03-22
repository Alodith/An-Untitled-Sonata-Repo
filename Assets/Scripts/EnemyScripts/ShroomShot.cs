using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomShot : MonoBehaviour
{
    public EnemyAIScript basicEnemyScript;
    public GameObject originalParent;
    public int damageToDeal;
    void Awake()
    {

        originalParent = transform.parent.gameObject;
        
        
        //Start coroutine that destroys the object after 5 seconds
        StartCoroutine(WaitForDestroy());


    }

    void Start()
    {
        //damageToDeal = originalParent.GetComponentInParent<EnemyAIScript>().damageToDeal;
        //unparent
        transform.parent = null;

    }
    // Update is called once per frame
    void Update()
    {
        //if object collides with terrain, destroy the object
        transform.parent = null;
        damageToDeal = originalParent.GetComponentInParent<EnemyAIScript>().damageToDeal;
    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Ground")
        {
            print("attack hit ground");
            Destroy(transform.gameObject);
        }
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerBasic>().TakeDamage(damageToDeal);

            Destroy(transform.gameObject);

        }


    }

    IEnumerator WaitForDestroy()
    {
        print("BossWaitForDestroy started");
        yield return new WaitForSeconds(5);
        Destroy(transform.gameObject);
    }
}
