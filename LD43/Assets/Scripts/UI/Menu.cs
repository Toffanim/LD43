using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//IMPORTANT (MTN5): Heavily inspired by Brackeys Menu
// https://www.youtube.com/watch?v=zc8ac_qUXQY

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
