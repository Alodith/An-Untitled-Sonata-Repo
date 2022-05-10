using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangeCollider : MonoBehaviour
{
    

    private void OnTriggerStay(Collider ChangeScene)
    {
        if (ChangeScene.gameObject.CompareTag("Player"))
        {
            print("player in collider");
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                FMODUnity.RuntimeManager.WaitForAllLoads();
            }
        }
        
    }
}
