using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0ObstacleConductor : MonoBehaviour
{
    // Conductor stuff
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
        songPositionInMeasures = (Mathf.Floor(songPositionInBeats) / 4);

        // The current beat in the current measure, indexed at zero
        // 0, 1, 2, 3 respectively
        beatPerMeasure = Mathf.Floor(songPositionInBeats) % 4;
        // ALL INDEXING is done with (actual measure number) - 1 due to zero indexing in this code

        if (songPositionInMeasures < 17 - 1 && songPositionInMeasures < 17 - 1)
        {
            // the little clicks twice a measure
            if (songPositionInMeasures % 2 == 0)
            {

                //peach
                myMaterial.color = new Color(1, 0.9f, 0.8f, 1);
            }
            // the main duration of each measure
            else
            {
                // lt yelw
                myMaterial.color = new Color(1, 1, 0.7f, 1);
            }

        }
        
        // first measure of first drop 
        else if (songPositionInMeasures >= 17 - 1 && songPositionInMeasures < 18 - 1)
        {
            if (beatPerMeasure == 0)
            {
                //pale lavelnder
                myMaterial.color = new Color(0.84f, 0.8f, 1, 1);
            }
            else if (beatPerMeasure == 1)
            {   //peach
                myMaterial.color = new Color(1, 0.9f, 0.8f, 1);
            }
            else if (beatPerMeasure == 2)
            {   //pale lavelnder
                myMaterial.color = new Color(0.84f, 0.8f, 1, 1);
            }
            else if (beatPerMeasure == 3)
            {   //peach
                myMaterial.color = new Color(1, 0.9f, 0.8f, 1);
            }
        }
        // first drop(minus the first measure of it)
        else if (songPositionInMeasures >= 18 - 1)
        {
            if (beatPerMeasure == 0)
            {
                //peach
                myMaterial.color = new Color(1, 0.9f, 0.8f, 1);
            }
            else if (beatPerMeasure == 1)
            {   //peach
                myMaterial.color = new Color(1, 0.9f, 0.8f, 1);
            }
            else if (beatPerMeasure == 2)
            {   // lt cyan
                myMaterial.color = new Color(0.8f, 0.97f, 1, 1);
            }
            else if (beatPerMeasure == 3)
            {   // lt cyan
                myMaterial.color = new Color(0.8f, 0.97f, 1, 1);
            }
        }

        

    }
}
