using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuRunner : MonoBehaviour
{
    public GameObject menu;
    public GameObject tutorial;
    public GameObject settings;
    public GameObject loadingScreen;
    public SettingsRunner settingsRunner;
    public AudioSource buttonSoundSource;

    void Start()
    {
        ShowMainMenu();
        loadingScreen.SetActive(false);
        settingsRunner.LoadVolume();
    }
    
    private void OnEnable()
    {
        InputHandler.OnEscPress += ShowMainMenu;
    }

    private void OnDisable()
    {
        InputHandler.OnEscPress -= ShowMainMenu;
    }

    public void ShowMainMenu()
    {
        CloseAllMenus();
    }
    
    void CloseAllMenus()
    {
        if (settings.activeSelf) // if exiting settings menu
        {
            PlayerPrefs.Save(); // save settings to file
            settings.SetActive(false);
        }
        tutorial.SetActive(false);
    }

    public void ShowTutorial()
    {
        CloseAllMenus();
        tutorial.SetActive(true); 
    }
    
    public void ShowSettings()
    {
        CloseAllMenus();
        settings.SetActive(true); 
    }

    public void ExitGame()
    {
        Debug.Log("Closing game");
        Application.Quit();
    }

    public void StartGame()
    {
        Debug.Log("Starting game");
        loadingScreen.SetActive(true); // show loading screen

        if (PlayerPrefs.GetInt("saveExists") == 1) // if save game exists, go to gameplay
        {
            SceneManager.LoadScene("Mystic Woods");
        }
        else // if there is no existing save, go to player and name select
        {
            SceneManager.LoadScene("CharacterEntry");
        }
    }

    public void PlayButtonSound()
    {
        buttonSoundSource.Play(0);
    }
}
