using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string otherScene;
    [SerializeField] private GameObject deathMenu;
    [SerializeField] private GameObject pauseMenu;

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void GoToScene()
    {
        SceneManager.LoadScene(otherScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseMenu()
    {
        if (Time.timeScale == 0)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void UnPauseMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void DeathMenu()
    {
        deathMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
