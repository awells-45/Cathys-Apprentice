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
    public PostProcessProfile brightness;
    public PostProcessLayer layer;
    public Slider brightnessSlider;

    private AutoExposure exposure;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            brightness.TryGetSettings(out exposure);
            brightnessSlider.value = PlayerPrefs.GetFloat("brightness", 1); // load settings into the slider
            SetBrightness(brightnessSlider.value);
        }
    }

    public void SetBrightness(float brightnessLevel)
    {
        exposure.keyValue.value = brightnessLevel;
        PlayerPrefs.SetFloat("brightness", brightnessLevel); // save brightness level settings
    }
}
