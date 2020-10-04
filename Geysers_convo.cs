using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Geysers_convo : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences4;
    private int index = 0;
    public float typingSpeed;

    public GameObject continuebutton;
    public GameObject Buttontoappear;
    private int i = 0;

    public GameObject PlayerM, PlayerF, SecSpeaker;
    private readonly string SelectedAvatar = "SelectedAvatar";
    private int SelAva;

    void Start()
    {
        //PlayerM.SetActive(false);
        //SecSpeaker.SetActive(false);
        //PlayerF.SetActive(false);
        //Buttontoappear.SetActive(false);
        StartCoroutine(Type());
    }

    void FixedUpdate()
    {
        if (textDisplay.text == sentences4[index])
        {
            continuebutton.SetActive(true);
        }

        SelAva = PlayerPrefs.GetInt(SelectedAvatar);
        if (SelAva == -1)
        {
            PlayerM.SetActive(false);
            PlayerF.SetActive(true);
            if (i % 2 != 0)
            {
                SecSpeaker.SetActive(true);
                PlayerF.SetActive(false);
            }
            else
            {
                SecSpeaker.SetActive(false);
                //i = i + 2;
                i++;
                i++;
            }
        }
        else if (SelAva == 1)
        {
            PlayerM.SetActive(true);
            PlayerF.SetActive(false);
            if (i % 2 != 0)
            {
                SecSpeaker.SetActive(true);
                PlayerM.SetActive(false);
            }
            else
            {
                SecSpeaker.SetActive(false);
                //i = i + 2;
                i++;
                i++;
            }
        }


    }
    IEnumerator Type()
    {
        foreach (char letter in sentences4[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void Continue()
    {
        continuebutton.SetActive(false);

        if (index < sentences4.Length - 1)
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
