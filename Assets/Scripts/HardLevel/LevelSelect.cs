using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public GameObject[] levels;
    public int selected = 0;

    public void PlayTheGame()
    {
        string temp;

        if (selected == 0)
        {
            temp = "TutorialLevel";

        }
        else if (selected == 1)
        {
            temp = "Level 0";
        }
        else
        {
            temp = "Level 1";
        }
        SceneManager.LoadScene(temp);
    }

    public void NextLevel()
    {
        levels[selected].SetActive(false);
        selected = (selected + 1) % levels.Length;
        levels[selected].SetActive(true);
        Debug.Log(selected);
    }

    public void previous()
    {
        levels[selected].SetActive(false);
        selected--;
        if (selected < 0)
        {
            selected += levels.Length;
        }
        levels[selected].SetActive(true);
        Debug.Log(selected);
    }
}
