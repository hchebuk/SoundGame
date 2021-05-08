using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This cs file handles Restarting, End Game, Win Game.

public class GameManager : MonoBehaviour
{
    bool GameEnded = false;
    public float restarttime; //Delay to restart after losing
    public GameObject LevelWinText;
    public void CompleteLevel() //Function to activate winning game text and restart after
    {
        LevelWinText.SetActive(true);
        Invoke("restart", 5f); //Delays by 5 seconds then restarts
    }
    public void EndGame()
    {
        if (GameEnded == false){ //End game only once
            GameEnded = true;
            //Restart
            Invoke("restart", restarttime);
        }
    }
    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
