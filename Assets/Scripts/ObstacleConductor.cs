using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleConductor : MonoBehaviour
{
    // Conductor stuff
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



   
    public GameObject block;
    [SerializeField] private Material myMaterial;


    void Start()
    {

        musicSource = GetComponent<AudioSource>();

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;


        block = GetComponent<GameObject>();

        myMaterial.color = Color.black;
        //renderer.material.color = new Color(0.5f, 1, 1, 1);
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

        if (songPositionInMeasures < 17 - 1)
        {

            if (songPositionInMeasures % 2 == 0)
            {

                // light cyan
                myMaterial.color = new Color(.70f, 1, 1, 1);
            }
            else
            {
                // ?
                myMaterial.color = new Color(0.5f, 0.8f, 0.25f, 1);
            }

        } else if (songPositionInMeasures >= 17-1 && songPositionInMeasures < 33-1)
        {
            if (songPositionInMeasures % 2 < 1)
            {
                // slightly (somethinger) magenta, I went 0.25 to 0.45 before stopping for the night
                myMaterial.color = new Color(0.5f, 0, 0.45f, 1);
            }
            else
            {   // slightly (darker?) magenta
                myMaterial.color = new Color(0.5f, 0, 0.25f, 1);
            }
        }

    }
}
