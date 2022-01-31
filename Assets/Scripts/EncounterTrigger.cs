using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterTrigger : MonoBehaviour
{
    public GameObject triggerwall;
    public GameObject physicalwall;
    public GameObject enemyUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartEncounter() {
        print("Encounter Started");
        enemyUI.SetActive(true);
        physicalwall.SetActive(true);
        triggerwall.SetActive(false);
        
    }

    public void EndEncounter()
    {
        print("Encounter Ended");
        enemyUI.SetActive(false);
        physicalwall.SetActive(false);
        triggerwall.SetActive(false);
    }
}
