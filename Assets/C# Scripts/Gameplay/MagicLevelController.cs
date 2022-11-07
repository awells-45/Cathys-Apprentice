using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MagicLevelController : MonoBehaviour
{
    public TMP_Text magicLevelText;
    
    private int _magicLevel;
    
    void Start()
    {
        SetMagicLevel(PlayerPrefs.GetInt("magic_level", 1));
    }

    public void IncreaseMagicLevel()
    {
        SetMagicLevel(_magicLevel + 1);
    }

    public void SetMagicLevel(int newMagicLevel)
    {
        _magicLevel = newMagicLevel;
        PlayerPrefs.SetInt("magic_level", _magicLevel);
        PlayerPrefs.Save();
        magicLevelText.text = _magicLevel.ToString();
    }

    public int GetMagicLevel()
    {
        return _magicLevel;
    }
    
}
