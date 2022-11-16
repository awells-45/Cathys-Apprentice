using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

/* References:
 * https://www.youtube.com/watch?v=XiJ-kb-NvV4
 */

public class BrightnessSetter : MonoBehaviour
{
    public Slider brightnessSlider;
    public PostProcessProfile brightness;
    public PostProcessLayer layer;

    private AutoExposure _exposure;
    
    void Start()
    {
        if (brightnessSlider != null)
        {
            brightness.TryGetSettings(out _exposure);
            brightnessSlider.value = PlayerPrefs.GetFloat("brightness", 1); // load settings into the slider
            SetBrightness(brightnessSlider.value);
        }
        else
        {
            brightness.TryGetSettings(out _exposure);
            SetBrightness(PlayerPrefs.GetFloat("brightness", 1));
        }
    }

    public void SetBrightness(float brightnessLevel)
    {
        _exposure.keyValue.value = brightnessLevel;
        PlayerPrefs.SetFloat("brightness", brightnessLevel); // save brightness level settings
    }
}
