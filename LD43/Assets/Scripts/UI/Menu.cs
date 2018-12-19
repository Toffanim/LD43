using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void Play()
    {
        //Launch game scene
        Debug.Log("PLAY");
    }
}
