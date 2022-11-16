using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalHandler : MonoBehaviour
{
    public LocationHandler locationHandler;
    public string location;
    public bool isPortal;

    private void OnTriggerEnter(Collider other)
    {
        if (isPortal)
        {
            PlayerPrefs.SetInt("wentThroughPortal", 1);
        }
        else
        {
            PlayerPrefs.SetInt("wentThroughPortal", 0);
        }
        PlayerPrefs.Save();
        locationHandler.GoToLocation(location);
    }
}
