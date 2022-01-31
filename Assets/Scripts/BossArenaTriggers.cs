using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArenaTriggers : MonoBehaviour
{

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BossArenaWall")
        {
            other.gameObject.GetComponent<EncounterTrigger>().StartEncounter();

        }
    }
}
