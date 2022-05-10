using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public GameObject ramp;
    public Animator a_anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Bullet")
        {
            
            Shot();
        }
    }

    public void Shot()
    {
        a_anim.SetBool("Shot", true);

    }

    public void Destroy()
    {
        ramp.SetActive(true);
        Destroy(gameObject);
    }
}
