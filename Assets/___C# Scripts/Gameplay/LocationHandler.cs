using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

//https://stackoverflow.com/questions/60189192/check-if-a-gameobject-has-been-assigned-in-the-inspector-in-unity3d-2019-3-05f

public class LocationHandler : MonoBehaviour
{
    public TMP_Text locationText;

    void Start()
    {
        if (locationText) // if the text has been assigned
        {
            LoadLocation();
        }
    }

    void LoadLocation()
    {
        if (PlayerPrefs.HasKey("location"))
        {
            locationText.text = PlayerPrefs.GetString("location");
        }
    }

    public void GoToLocation(string location)
    {
        PlayerPrefs.SetString("location", location);
        PlayerPrefs.Save();
        // loading screen?
        SceneManager.LoadScene(location);
        
    }
}