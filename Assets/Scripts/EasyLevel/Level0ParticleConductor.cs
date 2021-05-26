using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0ParticleConductor : MonoBehaviour
{


    public float songBpm = 140;

    //The number of seconds for each song beat
    public float secPerBeat;

    //Current song position, in seconds
    public float songPosition;

    //Current song position, in beats
    public float songPositionInBeats;

    public float songPositionInMeasures;

    //How many seconds have passed since the song started
    public float dspSongTime;

    //an AudioSource attached to this GameObject that will play the music.
    public AudioSource musicSource;

    public float beatPerMeasure;

    public ParticleSystem part;

    // Start is called before the first frame update
    void Start()
    {

        musicSource = GetComponent<AudioSource>();

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

    }

    // Update is called once per frame
    void Update()
    {
        // This is the main particle object
        part = GetComponent<ParticleSystem>();

        // This is controls part's "main" functions, we use it for color changing
        ParticleSystem.MainModule ma = part.main;

        songPosition = (float)(AudioSettings.dspTime - dspSongTime);

        //determine how many beats/measures since the song started
        songPositionInBeats = songPosition / secPerBeat;
        songPositionInMeasures = Mathf.Floor(songPositionInBeats) / 4;

        // The current beat in the current measure, indexed at zero
        // 0, 1, 2, 3 respectively
        beatPerMeasure = Mathf.Floor(songPositionInBeats) % 4;
        // ALL INDEXING is done with (actual measure number) - 1 due to zero indexing in this code

        // First 9 bars
        if (songPositionInMeasures < 9 - 1)
        {
            
            part.enableEmission = true;
            // light light yellow
            ma.startColor = new Color(1, 1, 0.7f, 1);


            // Start at measure 7
        }
        else if (songPositionInMeasures >= 9 - 1 && songPositionInMeasures < 17 - 1)
        {

            part.enableEmission = true;
            // peach
            ma.startColor = new Color(1, 0.9f, 0.7f, 1);            

        }
        else if (songPositionInMeasures >= 17 - 1 && songPositionInMeasures < 20 - 1)
        {


            part.enableEmission = true;
            // peach
            ma.startColor = new Color(1, 0.9f, 0.8f, 1);
         

        }
        // from intro to rest of song
        else if (songPositionInMeasures >= 20 - 1)
        {

            if (beatPerMeasure == 0 || beatPerMeasure == 2)
            {

                part.enableEmission = true;
                // light light red
                ma.startColor = new Color(1, 0.8f, 0.8f, 1);
            }
            else if (beatPerMeasure == 1 || beatPerMeasure == 3)
            {
                part.enableEmission = true;
                // light light yellow
                ma.startColor = new Color(1, 1, 0.7f, 1);
            }


            // Default case  - should not appear
        }
        else
        {
            
            
            part.enableEmission = true;
            // black
            ma.startColor = new Color(0, 0, 0, 1);
           
        }
    }
}