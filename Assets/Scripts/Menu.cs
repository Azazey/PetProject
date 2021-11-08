using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menuButton;
    [SerializeField] private GameObject _menuWindow;
    [SerializeField] private MonoBehaviour[] _componentsToDisable;

    [SerializeField] private bool _menuOpened = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_menuOpened)
        {
            OpenMenuWindow();
            Invoke("MenuOpened", 0.001f);
            Debug.Log("Menu Opened");
        }

        if (Input.GetKeyDown(KeyCode.Escape) && _menuOpened)
        {
            CloseMenuWindow();
            Invoke("MenuClosed", 0.001f);
            Debug.Log("Menu Closed");
        }
    }

    public void OpenMenuWindow()
    {
        _menuButton.SetActive(false);
        _menuWindow.SetActive(true);
        for (int i = 0; i < _componentsToDisable.Length; i++)
        {
            _componentsToDisable[i].enabled = false;
        }

        Time.timeScale = 0.01f;
    }

    public void CloseMenuWindow()
    {
        _menuButton.SetActive(true);
        _menuWindow.SetActive(false);
        for (int i = 0; i < _componentsToDisable.Length; i++)
        {
            _componentsToDisable[i].enabled = true;
        }

        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    private void MenuClosed()
    {
        _menuOpened = false;
    }

    private void MenuOpened()
    {
        _menuOpened = true;
    }
}
