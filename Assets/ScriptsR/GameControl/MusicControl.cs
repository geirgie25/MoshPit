using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public readonly float CurrentTempo;

    [SerializeField]
    Song[] SongPlaylist;
    [SerializeField]
    AudioSource[] Audios;

    int CurrentSongID = 0;
    Song CurrentSong;

    private void Awake()
    {
        CurrentSong = SongPlaylist[0];
        print(SongPlaylist.Length);
    }

    public void ChangeTrack()
    {
        if(CurrentSongID + 1< SongPlaylist.Length)
        {
            
            CurrentSongID += 1;
            print(CurrentSongID);
        }
        else
        {
            CurrentSongID = 0;
            print("what");
        }
        
        CurrentSong = SongPlaylist[CurrentSongID];
        Audios[CurrentSongID].volume = 1;
        foreach(AudioSource AS in Audios)
        {
            if(AS != Audios[CurrentSongID])
            {
                AS.volume = 0;
            }
        }
    }
    
    public float GetTempo()
    {
        return CurrentSong.Tempo;
    }
    public float GetSwitch()
    {
        return CurrentSong.SongSwitchWait;
    }
    public GameObject GetBullet()
    {
        return CurrentSong.Bullet;
    }
}
