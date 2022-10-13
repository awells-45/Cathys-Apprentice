using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuRunner : MonoBehaviour
{
    public GameObject menu;
    public GameObject tutorial;
    public GameObject settings;
    public GameObject loadingScreen;
    public SettingsRunner settingsRunner;

    private bool escKeyEnabled = true;
    
    void Start()
    {
        escKeyEnabled = true;
        ShowMainMenu();
        loadingScreen.SetActive(false);
        settingsRunner.LoadVolume();
    }

    void Update() // This should only be used for input
    {
        if (Input.GetKey(KeyCode.Escape) && (escKeyEnabled == true))
        {
            ShowMainMenu();
        }
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
        escKeyEnabled = false;
        loadingScreen.SetActive(true); // show loading screen
        
        // if save game exists, go to gameplay
        // else, go to player and name select
    }
}
