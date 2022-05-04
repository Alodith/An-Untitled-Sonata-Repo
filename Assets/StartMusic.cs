using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{

    private static FMOD.Studio.EventInstance Music;

    public MusicManager mM;
    // Start is called before the first frame update
    void Start()
    {
        Music = FMODUnity.RuntimeManager.CreateInstance("event:/Background/BGM1");
        Music.start();
        Music.release();
    }
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mM.AddToQueue(new MusicMessage(gameObject, "MusicStart", true));
    }
    
    public void MusicStart()
    {
        print("MusicStart");
        FMODUnity.RuntimeManager.PlayOneShot("event:/Background/BGM1", GetComponent<Transform>().position);
    }
    
}
