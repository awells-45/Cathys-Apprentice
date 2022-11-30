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
    public GameObject clickToContinuePrompt;
    public BadWordChecker badWordChecker;

    private string _welcomeText = "Hello there, and welcome to Cathy's Apprentice! You've come to the right place.";
    private string _goodbyeText = "Good choice! That's all I need for now. I'll see you in there...Buh bye!";
    private string _nameEntryInstructions = "First things first...what is your name?";
    private string _characterSelectionInstructions = "Hi NAME! It's nice to meet you! I can't quite see what you look like. Feel free to choose a character below!";

    private IEnumerator _textPlayer = null;

    private int _stateNum = -1; // states: 0 = welcome, 1 = name entry, 2 = char select; 3 = goodbye; 4 = start gameplay

    void Start()
    {
        NextState();
        PlayerPrefs.DeleteKey("playerName"); // delete old settings
        PlayerPrefs.DeleteKey("playerModel");
    }

    private void OnEnable()
    {
        InputHandler.AnyKeyPress += OnReceiveKeyPress;
    }

    private void OnDisable()
    {
        InputHandler.AnyKeyPress -= OnReceiveKeyPress;
    }

    void OnReceiveKeyPress()
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
                clickToContinuePrompt.SetActive(true);
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
                clickToContinuePrompt.SetActive(true);
                PlayText(_goodbyeText);
                break;
            default: // and case 4
                DisableScreens();
                StartGameplay();
                break;
        }
    }

    void PlayText(string text) // TODO - this functionality should potentially be moved to the TextPlayer class
    {
        if (_textPlayer != null)
        {
            StopCoroutine(_textPlayer);
        }
        _textPlayer = PlayText(textBox, text);
        StartCoroutine(_textPlayer);
    }

    public void StartGameplay()
    {
        PlayerPrefs.SetInt("saveExists", 1);
        PlayerPrefs.SetInt("seenTutorial", 0);
        PlayerPrefs.SetString("prevLocation", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
        
        Debug.Log("Starting game");
        DisableScreens();
        loadingScreen.SetActive(true); // show loading screen
        SceneManager.LoadScene("Mystic Woods");
    }

    public void SetPlayerName(string playerName)
    {
        PlayerPrefs.SetString("playerName", playerName);
    }

    public void ConfirmPlayerName()
    {
        if (DoesNameContainProfanity(PlayerPrefs.GetString("playerName"))) // TODO - do we want to inform the player that they have a bad name?
        {
            Debug.Log("Bad Name");
            PlayText("Are you sure that's your name?");
            return;
        }
        PlayerPrefs.Save();
        if (PlayerPrefs.HasKey("playerName") || (PlayerPrefs.GetString("playerName") != "")) // checking for valid player name
        {
            NextState();
        }
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
        clickToContinuePrompt.SetActive(false);
    }

    bool DoesNameContainProfanity(string nameToCheck)
    {
        return badWordChecker.CheckString(nameToCheck);
    }
}
