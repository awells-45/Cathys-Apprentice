using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterEntryRunner : TextPlayer
{
    public GameObject loadingScreen;
    public TMP_Text textBox;
    public GameObject nameEntry;
    public GameObject charModelSelect;

    private string _welcomeText = ".....";
    private string _goodbyeText = "Alright, that's all I need for now. Buh bye!";
    private string _nameEntryInstructions = "What is your name?";
    private string _characterSelectionInstructions = "I can't quit see you from here. What do you look like?";

    private int _stateNum = -1; // states: 0 = welcome, 1 = name entry, 2 = char select; 3 = goodbye; 4 = start gameplay

    void Start()
    {
        NextState();
    }

    private void OnEnable()
    {
        InputHandler.OnLeftClick += OnReceiveLeftClick;
    }

    private void OnDisable()
    {
        InputHandler.OnLeftClick -= OnReceiveLeftClick;
    }

    void OnReceiveLeftClick()
    {
        if ((_stateNum == 0) || (_stateNum == 3))
        {
            NextState();
        }
    }

    public void NextState()
    {
        _stateNum += 1;
        if (_stateNum > 4) // keep stateNum in range
        {
            _stateNum = 4;
        }

        switch (_stateNum)
        {
            case 0:
                DisableScreens();
                PlayText(_welcomeText);
                break;
            case 1:
                DisableScreens();
                PlayText(_nameEntryInstructions);
                nameEntry.SetActive(true);
                break;
            case 2:
                DisableScreens();
                PlayText(_characterSelectionInstructions);
                charModelSelect.SetActive(true);
                break;
            case 3:
                DisableScreens();
                PlayText(_goodbyeText);
                break;
            default: // and case 4
                DisableScreens();
                StartGameplay();
                break;
        }
    }

    void PlayText(string text)
    {
        StartCoroutine(PlayText(textBox, text));
    }

    public void StartGameplay()
    {
        PlayerPrefs.SetInt("saveExists", 1);
        PlayerPrefs.Save();
        
        Debug.Log("Starting game");
        DisableScreens();
        loadingScreen.SetActive(true); // show loading screen
        SceneManager.LoadScene("Gameplay");
    }

    void SetPlayerName(string playerName) // FIXME   - this needs to get called somewhere !!!!!!!!!!!!!!!!!!!!!!!!!!
    {
        PlayerPrefs.SetString("playerName", playerName);
        PlayerPrefs.Save();
    }
    
    public void SetPlayerModel(int playerModel)
    {
        PlayerPrefs.SetInt("playerModel", playerModel);
        PlayerPrefs.Save();
        NextState();
    }

    void DisableScreens()
    {
        loadingScreen.SetActive(false);
        nameEntry.SetActive(false);
        charModelSelect.SetActive(false);
    }
}
