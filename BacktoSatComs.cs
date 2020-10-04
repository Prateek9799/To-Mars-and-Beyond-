using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BacktoSatComs : MonoBehaviour
{
    public void backtoComsMenu()
    {
        SceneManager.LoadScene(4);
    }
    public void launch()
    {
        SceneManager.LoadScene(8);
    }
}
