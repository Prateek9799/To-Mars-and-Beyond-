using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index = 0;
    public float typingSpeed;

    public GameObject continuebutton;
    public GameObject Buttontoappear;
    private int i = 0;

    public Image Male, Female, Director;
    private readonly string SelectedAvatar = "SelectedAvatar";
    private int SelAva;

    void Start()
    {
        Buttontoappear.SetActive(false);
        StartCoroutine(Type());
    }

    void FixedUpdate()
    {
        if (textDisplay.text == sentences[index])
        {
            continuebutton.SetActive(true);
        }
        
        SelAva = PlayerPrefs.GetInt(SelectedAvatar);
        if (SelAva == -1)
        {
            Male.enabled = false;
            Female.enabled = true;
            if (i % 2 == 0)
            {
                Director.enabled = true;
                Female.enabled = false;
            }
            else
            {
                Director.enabled = false;
                //i = i + 2;
                i++;
                i++;
            }
        }
        else if (SelAva == 1)
        {
            Male.enabled = true;
            Female.enabled = false;
            if (i%2==0)
            {
                Director.enabled = true;
                Male.enabled = false;
            }
            else
            {
                Director.enabled = false;
                //i = i + 2;
                i++;
                i++;
            }
        }


    }
    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    
    public void Continue()
    {
        continuebutton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            i++;
            textDisplay.text = "";
            StartCoroutine(Type());
        } 
        else
        {
            textDisplay.text = "";
            Buttontoappear.SetActive(true);
            continuebutton.SetActive(false);
        } 
    }
}