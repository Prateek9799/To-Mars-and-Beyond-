using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommsChange : MonoBehaviour
{
    public void DSN()
    {
        SceneManager.LoadScene(5);
    }
    public void Laser()
    {
        SceneManager.LoadScene(6);
    }
    public void Con()
    {
        SceneManager.LoadScene(7);
    }
    public void SceneBwd()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
