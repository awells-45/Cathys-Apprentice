using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Runner : MonoBehaviour
{
    public AudioSource buttonSoundSource;
    public GameObject settings;
    public GameObject map;
    public GameObject recipes;
    public GameObject help;
    public GameObject potionBrewing;
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

        if (!PlayerPrefs.HasKey("seenTutorial"))
        {
            PlayerPrefs.SetInt("seenTutorial", 0);
        }
        if (PlayerPrefs.GetInt("seenTutorial") == 0)
        {
            PlayerPrefs.SetInt("seenTutorial", 1);
            PlayerPrefs.Save();
            CloseMenus();
            help.SetActive(true);
        }
    }

    public void OpenSettings()
    {
        PlayButtonSound();
        CloseMenus();
        settings.SetActive(true);
    }
    
    public void OpenMap()
    {
        PlayButtonSound();
        CloseMenus();
        map.SetActive(true);
    }
    
    public void OpenRecipes()
    {
        PlayButtonSound();
        CloseMenus();
        recipes.SetActive(true);
    }
    
    public void OpenHelp()
    {
        PlayButtonSound();
        CloseMenus();
        help.SetActive(true);
    }
    
    public void OpenPotionBrewing()
    {
        PlayButtonSound();
        CloseMenus();
        potionBrewing.SetActive(true);
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
        potionBrewing.SetActive(false);
    }
}
