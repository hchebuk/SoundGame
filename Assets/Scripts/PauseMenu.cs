using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Update is called once per frame
    public static bool paused = false;
    public GameObject pauseMenu;
    public AudioSource musicSource;
    public GameMaster gm;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (paused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
        musicSource.Play();
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
        musicSource.Pause();
    }

    public void Quit() 
    {
        Debug.Log("Going to main menu");
        Time.timeScale = 1f;
        paused = false;
        gm.lastCheckPointPos = new Vector3(0f, 3.3f, -44f);
        //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene("main menu");
    }
}
