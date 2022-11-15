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
    public GameObject loadingScreen;

    void Start()
    {
        loadingScreen.SetActive(false);
        SetLocationText(SceneManager.GetActiveScene().name);
    }

    public void GoToLocation(string location)
    {
        loadingScreen.SetActive(true);
        SceneManager.LoadScene(location);
    }

    void SetLocationText(string text)
    {
        locationText.text = text;
    }
}