using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UI_Runner : MonoBehaviour
{
    public AudioSource buttonSoundSource;
    public GameObject settings;
    public GameObject map;
    public GameObject recipes;
    public GameObject help;
    public GameObject potionBrewing;
    public GameObject quittingPrompt;
    public SettingsRunner settingsRunner;
    public TMP_Text quitingText;

    private void OnEnable()
    {
        InputHandler.OnEscPress += StartQuitSequence;
        InputHandler.OnPPress += OpenSettings;
        InputHandler.OnHPress += OpenHelp;
        InputHandler.OnMPress += OpenMap;
        InputHandler.OnBPress += OpenRecipes;
    }

    private void OnDisable()
    {
        InputHandler.OnEscPress -= StartQuitSequence;
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
        bool isActive = settings.activeSelf;
        PlayButtonSound();
        CloseMenus();
        settings.SetActive(!isActive);
    }
    
    public void OpenMap()
    {
        bool isActive = map.activeSelf;
        PlayButtonSound();
        CloseMenus();
        map.SetActive(!isActive);
    }
    
    public void OpenRecipes()
    {
        bool isActive = recipes.activeSelf;
        PlayButtonSound();
        CloseMenus();
        recipes.SetActive(!isActive);
    }
    
    public void OpenHelp()
    {
        bool isActive = help.activeSelf;
        PlayButtonSound();
        CloseMenus();
        help.SetActive(!isActive);
    }
    
    public void OpenPotionBrewing()
    {
        PlayButtonSound();
        CloseMenus();
        potionBrewing.SetActive(true);
    }

    public void StartQuitSequence()
    {
        CloseMenus();
        StartCoroutine(HoldToQuitCoroutine());
    }
    
    IEnumerator HoldToQuitCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < 50; ++i)
        {
            yield return new WaitForSeconds(0.1f);
            if (Input.GetKey(KeyCode.Escape))
            {
                quittingPrompt.SetActive(true);
                string text = "Closing game in " + (5 - (i / 10)) + " seconds...";
                Debug.Log(text);
                quitingText.text = text;
            }
            else
            {
                quittingPrompt.SetActive(false);
                quitingText.text = "";
                yield break;
            }
        }
        Quit();
    }

    public void Quit()
    {
        CloseMenus();
        PlayButtonSound();
        PlayerPrefs.Save();
        string text = "Closing game";
        Debug.Log(text);
        quitingText.text = text;
        quittingPrompt.SetActive(true);
        StartCoroutine(BriefWaitToQuitCoroutine());
    }
    
    IEnumerator BriefWaitToQuitCoroutine()
    {
        yield return new WaitForSeconds(0.35f);
        quittingPrompt.SetActive(false);
        Application.Quit();
    }
    
    public void PlayButtonSound()
    {
        buttonSoundSource.Play(0);
    }

    public void CloseMenus()
    {
        quittingPrompt.SetActive(false);
        settings.SetActive(false);
        PlayerPrefs.Save();
        map.SetActive(false);
        recipes.SetActive(false);
        help.SetActive(false);
        potionBrewing.SetActive(false);
    }
}
