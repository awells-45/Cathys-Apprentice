using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/* References:
 * https://www.youtube.com/watch?v=xNHSGMKtlv4
 * https://gamedevbeginner.com/how-to-use-player-prefs-in-unity/
 */

public class SettingsRunner : MonoBehaviour
{
    public AudioMixer mixer;
    
    public Slider volSlider;

    public void SetVolume(float volumeLevel) // volumeLevel is 0.0001 - 1
    {
        mixer.SetFloat("GameVolume", GetVolumeLog(volumeLevel));
        PlayerPrefs.SetFloat("volume", volumeLevel);
    }

    public void LoadVolume()
    {
        float volumeLevel = PlayerPrefs.GetFloat("volume", 0);
        mixer.SetFloat("GameVolume", GetVolumeLog(volumeLevel));
        volSlider.value = volumeLevel;
    }

    float GetVolumeLog(float volumeLevel)
    {
        return Mathf.Log10(volumeLevel) * 20;
    }

    public void DeleteSaveFile()
    {
        PlayerPrefs.SetInt("saveExists", 0);
        PlayerPrefs.Save();
        // FIXME - In the future, this should also delete the actual save
    }

}
