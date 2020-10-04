using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DSNinfo : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences2;
    private int index = 0;
    public float typingSpeed;

    public GameObject continuebutton;

    void Start()
    {
        StartCoroutine(Type());
    }

    void FixedUpdate()
    {
        if (textDisplay.text == sentences2[index])
        {
            continuebutton.SetActive(true);
        }
    }
    IEnumerator Type()
    {
        foreach (char letter in sentences2[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void Continue()
    {
        continuebutton.SetActive(false);

        if (index < sentences2.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continuebutton.SetActive(false);
        }
    }
}
