using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapRunner : MonoBehaviour
{
    public Image mapImage;
    public Sprite defaultMap;
    public Sprite mysticWoodsMap;
    public Sprite irishMeadowsMap;
    public Sprite wishingWellMap;
    public Sprite fairyGardensMap;
    
    void Start()
    {
        UpdateMapImage();
    }

    void OnEnable()
    {
        UpdateMapImage();
    }

    void UpdateMapImage()
    {
        string currSceneName = SceneManager.GetActiveScene().name;
        if (currSceneName.Equals("Mystic Woods") || currSceneName.Equals("Cathy's house"))
        {
            mapImage.sprite = mysticWoodsMap;
        }
        else if (currSceneName.Equals("Fairy Gardens"))
        {
            mapImage.sprite = fairyGardensMap;
        }
        else if (currSceneName.Equals("Irish Meadows"))
        {
            mapImage.sprite = irishMeadowsMap;
        } 
        else if (currSceneName.Equals("Wishing Well"))
        {
            mapImage.sprite = wishingWellMap;
        }
        else
        {
            mapImage.sprite = defaultMap;
        }
    }
}
