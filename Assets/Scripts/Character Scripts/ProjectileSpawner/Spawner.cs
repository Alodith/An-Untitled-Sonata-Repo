using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject playerAttackProjectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnAttack()
    {
        //Spawns projectile, and pushes it
        print("Projectile Spawned");
        GameObject Projectile = Instantiate(playerAttackProjectile, transform) as GameObject;
        Rigidbody rb = Projectile.GetComponent<Rigidbody>();
        //rb.velocity = transform.forward * 20;

    }
}
