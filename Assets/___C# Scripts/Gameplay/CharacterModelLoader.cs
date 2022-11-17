using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModelLoader : MonoBehaviour
{
    public GameObject charModel0;
    public GameObject charModel1;
    public GameObject charModel2;
    void Start()
    {
        charModel0.SetActive(false);
        charModel1.SetActive(false);
        charModel2.SetActive(false);
        int playerModelNum = PlayerPrefs.GetInt("playerModel", 0);
        switch (playerModelNum)
        {
            case 0:
                charModel0.SetActive(true);
                break;
            case 1:
                charModel1.SetActive(true);
                break;
            case 2:
                charModel2.SetActive(true);
                break;
            default:
                charModel0.SetActive(true);
                break;
        }
    }
}
