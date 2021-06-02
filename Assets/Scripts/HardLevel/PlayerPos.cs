using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
    private GameMaster gm;
    public Checkpoint check;
    public tracker track;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            track.died = true;
            DontDestroyOnLoad(track);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}