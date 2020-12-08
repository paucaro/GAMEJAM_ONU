using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
   public void Game()
    {
        SceneManager.LoadScene(1);
    }
    public void Beginning()
    {
        SceneManager.LoadScene(0);
    }
    public void MoreInfo()
    {

    }
}
