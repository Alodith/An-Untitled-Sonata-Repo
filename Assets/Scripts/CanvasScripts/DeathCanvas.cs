using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        //Restart the level
        //This is a stand in
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //If you manage to make a save system, make it from the last save
    }

    public void QuitToMenu()
    {
        //Load the main menu
        SceneManager.LoadScene("Menu");
    }
}
