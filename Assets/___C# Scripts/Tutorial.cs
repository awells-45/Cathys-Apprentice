using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject prevButton;
    public GameObject nextButton;
    
    public Image tutorialImage;
    public Sprite tutImage0;
    public Sprite tutImage1;
    public Sprite tutImage2;
    public Sprite tutImage3;
    
    private int _numPages = 4;
    private int _currPage = 0;
    
    void OnEnable()
    {
        GoToPage(0);
    }

    public void NextPage()
    {
        if (_currPage < _numPages - 1)
        {
            GoToPage(_currPage + 1);
        }
    }
    
    public void PrevPage()
    {
        if (_currPage > 0)
        {
            GoToPage(_currPage - 1);
        }
    }

    void GoToPage(int pageNum)
    {
        _currPage = pageNum;
        SetButtonVisibility(pageNum);
        switch (pageNum) // set tutorial image
        {
            case 0:
                tutorialImage.sprite = tutImage0;
                break;
            case 1:
                tutorialImage.sprite = tutImage1;
                break;
            case 2:
                tutorialImage.sprite = tutImage2;
                break;
            case 3:
                tutorialImage.sprite = tutImage3;
                break;
            default:
                tutorialImage.sprite = tutImage0;
                break;
        }
    }

    void SetButtonVisibility(int pageNum)
    {
        if (pageNum == 0)
        {
            nextButton.SetActive(true);
            prevButton.SetActive(false);
        }
        else if (pageNum == _numPages - 1)
        {
            nextButton.SetActive(false);
            prevButton.SetActive(true);
        }
        else
        {
            nextButton.SetActive(true);
            prevButton.SetActive(true);
        }
    }
}
