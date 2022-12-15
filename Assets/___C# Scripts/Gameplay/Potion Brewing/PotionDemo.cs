using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionDemo : MonoBehaviour
{
    public GameObject potionBrewing;
    public UI_Runner uiRunner;
    void Start()
    {
        potionBrewing.SetActive(false);
    }

    public void ToggleBrewing()
    {
        uiRunner.PlayButtonSound();
        bool isActive = potionBrewing.activeSelf;
        uiRunner.CloseMenus();
        potionBrewing.SetActive(!isActive);
    }
}
