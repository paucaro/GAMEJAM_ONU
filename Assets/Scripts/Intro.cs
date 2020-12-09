using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public GameObject moreInfo;
    public GameObject creditsC;
    public bool cardActive;
    public void Game()
    {
        SceneManager.LoadScene(1);
    }
    public void Start()
    {
        moreInfo.SetActive(false);
        creditsC.SetActive(false);
        cardActive = false;
    }
    public void Update()
    {
        if(cardActive)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                moreInfo.SetActive(false);
                creditsC.SetActive(false);
                cardActive = false;
            }
        }
    }
    public void Beginning()
    {
        SceneManager.LoadScene(0);
    }
    public void MoreInfo()
    {
        moreInfo.SetActive(true);
        cardActive = true;
    }
    public void Credits()
    {
        creditsC.SetActive(true);
        cardActive = true;

    }
}
