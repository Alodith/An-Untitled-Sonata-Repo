using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAttacking : MonoBehaviour
{
    public bool attacking = false;
    public Spawner spawner;
    public MusicManager mM;
    public AudioSource attackMusicAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(attacking == true)
        {
            mM.AddToQueue(new MusicMessage(gameObject, "AttackSound", true));
            //mM.QueueOrNearBeat(5, new MusicMessage(gameObject, "Attacking", false));
            Attacking();
        }
    }

    public void Attacking()
    {
        print("attacking");
        //Spawn projectile that shoots from the player.
        spawner.SpawnAttack();
        attacking = false;
    }
    public void AttackSound()
    {
        //SoundHere
        attackMusicAudio.Play(0);
        Debug.Log("AttackBeat");
        
    }
}
