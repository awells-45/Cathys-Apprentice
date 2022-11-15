using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPlayer : MonoBehaviour
{
    public IEnumerator PlayText(TMP_Text textBox, string textToPlay, float charPerSecond = 20.0f)
    {
        textBox.text = "";
        foreach (char currChar in textToPlay)
        {
            textBox.text += currChar;
            yield return new WaitForSeconds(1/charPerSecond);
        }
    }
}
