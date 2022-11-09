using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

// https://learn.microsoft.com/en-us/dotnet/api/system.io.stringreader?view=net-7.0
// https://docs.unity3d.com/ScriptReference/TextAsset-text.html

public class BadWordChecker : MonoBehaviour
{
    public TextAsset bannedWordsList;

    public bool CheckString(string strToTest)
    {
        bool hasBadWord = false;
        StringReader reader = new StringReader(bannedWordsList.text); // creating a StringReader to parse the text
        string currentWordToCheck = reader.ReadLine();
        while (currentWordToCheck != null) // while there is still data to read
        {
            if (strToTest.ToLower().Contains(currentWordToCheck.ToLower()))
            {
                hasBadWord = true;
                break;
            }
            currentWordToCheck = reader.ReadLine();
        }
        return hasBadWord;
    }
}
