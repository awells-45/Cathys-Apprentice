using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

// https://stackoverflow.com/questions/60189192/check-if-a-gameobject-has-been-assigned-in-the-inspector-in-unity3d-2019-3-05f
// https://subscription.packtpub.com/book/game-development/9781800207806/12/ch12lvl1sec32/using-try-catch

public class LocationHandler : MonoBehaviour
{
    public TMP_Text locationText;
    public GameObject loadingScreen;
    public GameObject player;
    public CharacterController characterController;
    public GameObject inventory;
    public GameObject inventoryText;
    public AudioClip portalSound1;
    public AudioClip portalSound2;
    public AudioSource soundSource;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2) // Mystic Woods
        {
            string lastLocation = PlayerPrefs.GetString("prevLocation", "none");
            
            Debug.Log(lastLocation);
            
            if (lastLocation.Equals("Cathy's house"))
            {
                GoToPosition(-17.3f, -22.73778f, -42.16f, 162.6f);
            }
            else if (lastLocation.Equals("Fairy Gardens"))
            {
                GoToPosition(-40.0f, -22.73778f, -84.7f, 65.8f);
            }
            else if (lastLocation.Equals("Wishing Well"))
            {
                GoToPosition(-7.079504f, -22.73778f, -73.196f, -14.3f);
            }
            else if (lastLocation.Equals("Irish Meadows"))
            {
                GoToPosition(19.9f, -22.73778f, -47.2f, -108.5f);
            }
            else // coming from the menus
            {
                GoToPosition(-7.079504f, -22.73778f, -73.196f, -14.3f);
            }
        }

        if (PlayerPrefs.GetInt("wentThroughPortal", 0) == 1)
        {
            PlayRandPortalSound();
            PlayerPrefs.SetInt("wentThroughPortal", 0);
            PlayerPrefs.Save();
        }
        SetLocationText(SceneManager.GetActiveScene().name);
        loadingScreen.SetActive(false);
        SetInventoryActivity(true);
    }

    public void GoToLocation(string location)
    {
        SetInventoryActivity(false);
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
    
    private void PlayRandPortalSound()
    {
        if ((portalSound1 != null) && (portalSound2 != null))
        {
            try
            {
                int randInt = UnityEngine.Random.Range(0, 2);
                AudioClip audioClip;
                switch (randInt)
                {
                    case(0):
                        audioClip = portalSound1;
                        break;
                    case(1):
                    default:
                        audioClip = portalSound2;
                        break;
                }
                soundSource.PlayOneShot(audioClip);
            }
            catch (NullReferenceException)
            {
                Debug.Log("No sound source");
            }
        }
    }

    void SetInventoryActivity(bool active)
    {
        if ((inventory != null) && (inventoryText != null))
        {
            inventory.SetActive(active);
            inventoryText.SetActive(active);
        }
    }
}