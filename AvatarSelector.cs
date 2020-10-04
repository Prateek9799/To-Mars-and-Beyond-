using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvatarSelector : MonoBehaviour
{
    public GameObject male;
    public GameObject female;
    private readonly string SelectedAvatar = "SelectedAvatar";
    //private int index;
    public void SelMale()
    {
        PlayerPrefs.SetInt(SelectedAvatar, 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void SelFemale()
    {
        PlayerPrefs.SetInt(SelectedAvatar, -1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
