using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsRunner : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetVolume(float volumeLevel) // volumeLevel is 0.0001 - 1
    {
        float volLevelLog = Mathf.Log10(volumeLevel) * 20;
        mixer.SetFloat("GameVolume", volLevelLog);
    }

}
