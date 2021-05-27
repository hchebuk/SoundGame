using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public GameObject[] levels;
    public int selected = 0;

    public void Next() {
        levels[selected].SetActive(false);
        selected = (selected + 1) % levels.Length;
        levels[selected].SetActive(true);
    }

    public void Previous() {
        levels[selected].SetActive(false);
        selected--;
        if (selected < 0) {
            selected += levels.Length;
        }
        levels[selected].SetActive(true);
    }

    public void PlayTheGame() {
        PlayerPrefs.SetInt("selected", selected);
        string temp;
        if (selected == 0)
        {
            temp = "TutorialLevel";
        }
        else if (selected == 1)
        {
            temp = "Level 0";
        }
        else {
            temp = "Level 1";
        }
        SceneManager.LoadScene(temp, LoadSceneMode.Single);
    }
}
