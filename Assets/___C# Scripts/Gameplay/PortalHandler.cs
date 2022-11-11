using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalHandler : MonoBehaviour
{
    public LocationHandler locationHandler;
    public string location;

    private void OnTriggerEnter(Collider other)
    {
        locationHandler.GoToLocation(location);
    }
}
