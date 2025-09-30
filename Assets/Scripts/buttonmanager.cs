using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonmanager : MonoBehaviour
{
   public void startGame()
    {
        SceneManager.LoadScene(0);
    }

    public void seecontrols()
    {
        SceneManager.LoadScene(2);
    }

    public void backtomenu()
    {
        SceneManager.LoadScene(1);
    }
}
