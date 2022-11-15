using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Runner : MonoBehaviour
{
    public AudioSource buttonSoundSource;
    public GameObject settings;
    public GameObject map;
    public GameObject recipes;
    public GameObject help;
    public GameObject loadingScreen;
    public SettingsRunner settingsRunner;

    private void OnEnable()
    {
        InputHandler.OnEscPress += Quit;
        InputHandler.OnPPress += OpenSettings;
        InputHandler.OnHPress += OpenHelp;
        InputHandler.OnMPress += OpenMap;
        InputHandler.OnBPress += OpenRecipes;
    }

    private void OnDisable()
    {
        InputHandler.OnEscPress -= Quit;
        InputHandler.OnPPress -= OpenSettings;
        InputHandler.OnHPress -= OpenHelp;
        InputHandler.OnMPress -= OpenMap;
        InputHandler.OnBPress -= OpenRecipes;
    }
    
    void Start()
    {
        settingsRunner.LoadVolume();
        CloseMenus();
    }

    public void OpenSettings()
    {
        PlayButtonSound();
        CloseMenus();
        settings.SetActive(!settings.activeSelf);
    }
    
    public void OpenMap()
    {
        PlayButtonSound();
        CloseMenus();
        map.SetActive(!map.activeSelf);
    }
    
    public void OpenRecipes()
    {
        PlayButtonSound();
        CloseMenus();
        recipes.SetActive(!recipes.activeSelf);
    }
    
    public void OpenHelp()
    {
        PlayButtonSound();
        CloseMenus();
        help.SetActive(!help.activeSelf);
    }

    public void Quit()
    {
        PlayButtonSound();
        CloseMenus();
        PlayerPrefs.Save();
        Debug.Log("Closing game");
        Application.Quit();
    }
    
    public void PlayButtonSound()
    {
        buttonSoundSource.Play(0);
    }

    public void CloseMenus()
    {
        settings.SetActive(false);
        PlayerPrefs.Save();
        map.SetActive(false);
        recipes.SetActive(false);
        help.SetActive(false);
        loadingScreen.SetActive(false);
    }
}
