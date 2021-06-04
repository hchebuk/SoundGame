using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicConductor : MonoBehaviour
{
    //Song beats per minute
    //This is determined by the song you're trying to sync up to
    public float songBpm;

    //The number of seconds for each song beat
    public float secPerBeat;

    //Current song position, in seconds
    public float songPosition;

    //Current song position, in beats
    public float songPositionInBeats;

    //How many seconds have passed since the song started
    public float dspSongTime;
    //the time since the lastCheckpoint

    public tracker track; //used to track the game when we reload

    //an AudioSource attached to this GameObject that will play the music.
    public AudioSource musicSource;
    // Start is called before the first frame update
    void Start()
    {
        // Setting up song variables 
        //Load the AudioSource attached to the Conductor GameObject
        musicSource = GetComponent<AudioSource>();

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        //Start the music
        if (track.checkPoint && track.died)
        {
            Debug.Log(track.lastCheck);
            musicSource.time = track.lastCheck;
            musicSource.Play();
            track.died = false;
        } else {
            musicSource.Play();
        }
    }   

    // Update is called once per frame
    void Update()
    {
        // Calculating beats 
        //determine how many seconds since the song started
        //Debug.Log(deathTime);
       
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);
        //Debug.Log(songPosition);


        //determine how many beats since the song started
        songPositionInBeats = songPosition / secPerBeat;
    }
}
