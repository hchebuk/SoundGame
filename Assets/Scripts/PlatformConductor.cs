using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformConductor : MonoBehaviour
{
    // Start is called before the first frame update
    public float songBpm;

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

    public float myValue;

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
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);

        //determine how many beats/measures since the song started
        songPositionInBeats = songPosition / secPerBeat;
        songPositionInMeasures = Mathf.Floor(songPositionInBeats) / 4;

        // The current beat in the current measure, indexed at zero
        // 0, 1, 2, 3 respectively
        beatPerMeasure = Mathf.Floor(songPositionInBeats) % 4;
        // ALL INDEXING is done with (actual measure number) - 1 due to zero indexing in this code

        myValue = 0.1f;

        Shader.SetGlobalFloat("_myValue", myValue);

        if (songPositionInMeasures >= 17 - 1 && songPositionInMeasures < 3000)
        {
            myValue = 0.2f;
            Shader.SetGlobalFloat("_myValue", myValue);
        }

    }
}
