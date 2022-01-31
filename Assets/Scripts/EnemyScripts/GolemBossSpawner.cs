using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemBossSpawner : MonoBehaviour
{
    public GameObject Rock;
    public Transform playerAim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerAim);
    }

    public void SpawnAttack()
    {
        //Spawns projectile, and pushes it
        print("Projectile Spawned");
        GameObject Projectile = Instantiate(Rock, transform) as GameObject;
        Rigidbody rb = Projectile.GetComponent<Rigidbody>();
        
        rb.velocity = transform.forward * 45;

    }
}
