using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomProjSpawner : MonoBehaviour
{

    public GameObject theProjectile;
    public Transform playerAim;
    

    // Start is called before the first frame update
    void Start()
    {
        playerAim = FindObjectOfType<Player>().transform;
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
        GameObject Projectile = Instantiate(theProjectile, transform) as GameObject;
        Rigidbody rb = Projectile.GetComponent<Rigidbody>();
        

       
        rb.velocity = transform.forward * 5;

    }
}
