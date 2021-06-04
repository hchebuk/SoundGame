using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    public AudioSource[] musicSources;
    public int musicBPM, timeSignature, barsLength;
    private float loopPointMinutes, loopPointSeconds;
    private double time;
    private int nextSource;
    void Start()
    {
        loopPointMinutes = (barsLength * timeSignature) / musicBPM;

        loopPointSeconds = loopPointMinutes * 60;

        time = AudioSettings.dspTime;

        musicSources[0].Play();
        nextSource = 1;
    }

    void Update()
    {
        if (!musicSources[nextSource].isPlaying)
        {
            time += loopPointSeconds;

            musicSources[nextSource].PlayScheduled(time);

            nextSource = 1 - nextSource; //Switch to other AudioSource
        }
    }
}
