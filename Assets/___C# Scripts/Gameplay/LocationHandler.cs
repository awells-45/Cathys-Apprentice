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
    public GameObject player;
    public CharacterController characterController;

    void Start()
    {
        string currSceneName = SceneManager.GetActiveScene().name;
        if (currSceneName.Equals("Mystic Woods"))
        {
            string lastLocation = PlayerPrefs.GetString("prevLocation", "none");
            
            if (lastLocation.Equals("Cathy's House"))
            {
                GoToPosition(-28.9f, -22.73778f, -10.6f, 160.0f);
            }
            else if (lastLocation.Equals("Fairy Gardens"))
            {
                GoToPosition(-120.0f, -22.73778f, -28.0f, 72.0f);
            }
            else if (lastLocation.Equals("Wishing Well"))
            {
                GoToPosition(-6.6f, -22.73778f, -80.0f, -17.409f);
            }
            else if (lastLocation.Equals("Irish Meadows"))
            {
                GoToPosition(53.1111f, -22.73778f, 24.83964f, -115.0f);
            }
            else // coming from the menus
            {
                GoToPosition(-19.5f, -22.73778f, -41.3f, -17.409f);
            }
        }
        SetLocationText(currSceneName);
        loadingScreen.SetActive(false);
    }

    public void GoToLocation(string location)
    {
        loadingScreen.SetActive(true);
        PlayerPrefs.SetString("prevLocation", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
        SceneManager.LoadScene(location);
    }

    void SetLocationText(string text)
    {
        locationText.text = text;
    }

    public void GoToPosition(float x, float y, float z, float rotY)
    {
        characterController.enabled = false;
        player.transform.localPosition = new Vector3(x, y, z);
        player.transform.Rotate(00.0f, rotY, 0.0f, Space.World);
        characterController.enabled = true;
    }
}