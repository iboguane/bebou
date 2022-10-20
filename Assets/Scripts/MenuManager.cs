using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string otherScene;

    public void GoToScene()
    {
        SceneManager.LoadScene(otherScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
