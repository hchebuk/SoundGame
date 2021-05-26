using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void PlayTheGame()
  {
    SceneManager.LoadScene("Level 1");
  }

  public void QuitTheGame()
    {
    Debug.Log("QUIT THE GAME");
    Application.Quit(); 
    }
}
