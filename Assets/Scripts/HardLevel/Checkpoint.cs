using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameMaster gm;
    public GameObject player;
    public tracker track; 
    public AudioSource musicSource;
    public MusicConductor mc;
    public float musicCheckpoint;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            gm.lastCheckPointPos = player.transform.position;
            gm.lastCheckPointPos.y = 0.3f; //make sure we don't start in the air
            track.lastCheck  = mc.musicSource.time;
            track.checkPoint = true;
            Debug.Log(track.lastCheck);
            Debug.Log("Checkpoint given");            
        }
    }
}
