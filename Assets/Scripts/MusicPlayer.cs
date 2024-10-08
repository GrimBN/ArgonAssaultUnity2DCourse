﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    //MusicPlayer musicPlayer;
    
    void Awake()
    {
        var musicPlayers = FindObjectsOfType<MusicPlayer>();
        if(musicPlayers.Length > 1)
        {
            Destroy(gameObject);
        }
        else 
        {
            DontDestroyOnLoad(this);
        }
    }
}
