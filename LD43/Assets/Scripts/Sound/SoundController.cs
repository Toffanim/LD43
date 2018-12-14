using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {


    public AudioSource bgmMusic { get; set; }// NOT MAND

	// Use this for initialization
	void Start () {
        bgmMusic = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        //bgmMusic = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();
        if (!!pc)
        {
            playBGM();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();
        if (!!pc)
        {
            pauseBGM();
        }
    }


    public void playBGM()
    {
        if (bgmMusic != null)
        {
            bgmMusic.Play(0);
        }
    }

    public void pauseBGM()
    {
        if (bgmMusic != null)
            bgmMusic.Pause();
    }

    public void unpauseBGM()
    {
        if (bgmMusic != null)
            bgmMusic.UnPause();
    }



}
