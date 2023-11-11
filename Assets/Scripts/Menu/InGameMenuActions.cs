using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenuActions : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameLauncher _launcher;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
    public void OpenPauseMenu()
    {
        _pauseMenu.SetActive(true);
        _launcher.Pause();
    }

    public void ClosePauseMenu()
    {
        _pauseMenu.SetActive(false);
        _launcher.Unpause();
    }

    public void GoMain()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
