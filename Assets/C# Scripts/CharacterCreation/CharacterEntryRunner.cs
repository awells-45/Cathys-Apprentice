using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterEntryRunner : MonoBehaviour
{
    public GameObject loadingScreen;

    void Start()
    {
        loadingScreen.SetActive(false);
    }

    void Update() // This should only be used for input
    {
        
    }

    public void StartGame()
    {
        Debug.Log("Starting game");
        loadingScreen.SetActive(true); // show loading screen
        // go to gameplay
    }
}
