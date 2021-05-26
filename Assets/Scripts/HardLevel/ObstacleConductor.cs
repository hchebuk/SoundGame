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
        songPositionInMeasures = (Mathf.Floor(songPositionInBeats) / 4);

        // The current beat in the current measure, indexed at zero
        // 0, 1, 2, 3 respectively
        beatPerMeasure = Mathf.Floor(songPositionInBeats) % 4;
        // ALL INDEXING is done with (actual measure number) - 1 due to zero indexing in this code

        if (songPositionInMeasures < 17 - 1 && songPositionInMeasures < 10 - 1)
        {
            // the little clicks twice a measure
            if (songPositionInMeasures % 2 == 0)
            {

                //red
                myMaterial.color = new Color(1, 0.18f, 0.40f, 1);
            }
            // the main duration of each measure
            else
            {
                // blue
                myMaterial.color = new Color(.32f, 0.18f, 1, 1);
                
            }

        }
        // first measure of second half of intro
        else if (songPositionInMeasures >= 10 - 1 && songPositionInMeasures < 13 - 1)
        {
            // blue
            myMaterial.color = new Color(.32f, 0.18f, 1, 1);
        }
        // rest of second half of intro
        else if (songPositionInMeasures >= 13 - 1 && songPositionInMeasures < 17 - 1)
        {
            // the little clicks twice a measure
            if (songPositionInMeasures % 2 == 0)
            {

                //red
                myMaterial.color = new Color(1, 0.18f, 0.40f, 1);
            }
            // the main duration of each measure
            else
            {
                // blue
                myMaterial.color = new Color(.32f, 0.18f, 1, 1);
            }
        }
        // first measure of first drop 
        else if (songPositionInMeasures >= 17-1 && songPositionInMeasures < 18-1)
        {
            if (beatPerMeasure == 0)
            {
                //dark red
                myMaterial.color = new Color(1, 0.2f, 0.2f, 1);
            }
            else if (beatPerMeasure == 1)
            {   // red red
                myMaterial.color = new Color(1, 0, 0, 1);
            }
            else if (beatPerMeasure == 2)
            {   // orange
                myMaterial.color = new Color(1, 0.50f,0, 1);
            }
            else if (beatPerMeasure == 3)
            {   // slightly (darker?) magenta
                myMaterial.color = new Color(1, 1, 0, 1);
            }
        }
        // first drop(minus the first measure of it)
        else if (songPositionInMeasures >= 18 - 1 && songPositionInMeasures < 33 - 1)
        {
            if (beatPerMeasure == 0)
            {
                //light orange
                myMaterial.color = new Color(1, 0.8f, 0.49f, 1);
            }
            else if (beatPerMeasure == 1)
            {   // slightly (darker?) magenta
                myMaterial.color = new Color(1, 0.69f, 0.43f, 1);
            }
            else if (beatPerMeasure == 2)
            {   // slightly (darker?) magenta
                myMaterial.color = new Color(1, 0.6f, 0.19f, 1);
            }
            else if (beatPerMeasure == 3)
            {   // slightly (darker?) magenta
                myMaterial.color = new Color(1, 0.52f, 0.05f, 1);
            }
        }

        // first two fake measure of breadkwon
        else if (songPositionInMeasures >= 33-1 && songPositionInMeasures < 35 - 1)
        {
            myMaterial.color = new Color(.32f, 0.18f, 1, 1);
            
        }

        // "breakdown" - first 2 fake measures
        else if (songPositionInMeasures >= 35-1 && songPositionInMeasures < 49 - 1)
        {
            if (beatPerMeasure == 0)
            {
                //dark blue
                myMaterial.color = new Color(0.68f, 0.90f, 1, 1);
            }
            else if (beatPerMeasure == 1)
            {   // less d blue
                myMaterial.color = new Color(0.45f, 0.79f, 1, 1);
            }
            else if (beatPerMeasure == 2)
            {   // even less dark kinda light blu
                myMaterial.color = new Color(0.23f, 0.68f, 1, 1);
            }
            else if (beatPerMeasure == 3)
            {   // light blue
                myMaterial.color = new Color(0, 0.50f, 1, 1);
            }
        }
        // slippery third drop
        else if (songPositionInMeasures >= 49 - 1 && songPositionInMeasures < 65 - 1)
        {
            if (songPositionInMeasures % 2 < 1)
            {
                // yellow
                myMaterial.color = new Color(1, 1, 0.52f, 1);
            }
            else
            {   // orange
                myMaterial.color = new Color(1f, 0.77f, 0.52f, 1);
            }
        }
        // interlude
        else if (songPositionInMeasures >= 65 - 1 && songPositionInMeasures < 81 - 1)
        {
            if (songPositionInMeasures % 2 < 1)
            {
                // very light orange
                myMaterial.color = new Color(0.99f, 0.87f, 0.70f, 1);
            }
            else
            {   // very light blu
                myMaterial.color = new Color(0.94f, 0.93f, 0.7f, 1);
            }
        }
        // first guitar drop
        else if (songPositionInMeasures >= 81 - 1 && songPositionInMeasures < 97 - 1)
        {
            if (beatPerMeasure ==  0)
            {
                // cyan
                myMaterial.color = new Color(0, 1, 1, 1);
            }
            else if (beatPerMeasure == 1)
            {   // green
                myMaterial.color = new Color(0, 1,0.5f, 1);
            }
            else if (beatPerMeasure == 2)
            {   // lighter green
                myMaterial.color = new Color(0.5f, 1, 0, 1);
            }
            else if (beatPerMeasure == 3)
            {   // yellow
                myMaterial.color = new Color(1, 1, 0, 1);
            }
        }
        // 2nd guitar drop - perfect 4th
        else if (songPositionInMeasures >= 97 - 1 && songPositionInMeasures < 111 - 1)
        {
            if (beatPerMeasure == 0)
            {
                // l blue
                myMaterial.color = new Color(0, 0.5f, 1, 1);
            }
            else if (beatPerMeasure == 1)
            {   //blue
                myMaterial.color = new Color(0, 0, 1, 1);
            }
            else if (beatPerMeasure == 2)
            {   // violet
                myMaterial.color = new Color(0.69f, 0.54f, 1, 1);
            }
            else if (beatPerMeasure == 3)
            {   // yellow
                myMaterial.color = new Color(1, 0.54f, 1, 1);
            }
        }
        // 2nd to last bar of perfect 4th to last jazzy drop
        else if (songPositionInMeasures >= 111 -1 && songPositionInMeasures < 117 - 1)
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
        // Jazzy drop to last 2 bars of it
        else if (songPositionInMeasures >= 117 - 1 && songPositionInMeasures < 131 - 1)
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
        // last 2 bars of jazzy drop
        else if (songPositionInMeasures >= 131 - 1 && songPositionInMeasures < 133 - 1)
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
        // 2nd to last bar + outtro
        else if (songPositionInMeasures >= 133 - 1)
        {
            // white
            myMaterial.color = new Color(1, 1, 1, 1);
        }

    }
}
