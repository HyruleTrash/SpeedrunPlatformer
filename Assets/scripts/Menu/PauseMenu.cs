using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject DeathMenu;
    private bool Paused = false;

    public void Update()
    {
        if (Input.GetKeyDown("escape") && !Paused)
        {
            Paused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Resume()
    {
        if (Paused)
        {
        Paused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        }
    }

    public void Home()
    {
        if (Paused)
        {
            Paused = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void Died()
    {
        if (!Paused)
        {
            Paused = true;
            DeathMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Restart()
    {
        if (Paused)
        {
            Paused = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
}
