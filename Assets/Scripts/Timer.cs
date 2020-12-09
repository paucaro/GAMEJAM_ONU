using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text time;
    public float remainingTime;
    public bool RunTimer;
    public static Timer instance;

    public void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        RunTimer = false;
    }
    public void Update()
    {
        if (RunTimer)
        {
            remainingTime -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(remainingTime / 60);
            float seconds = Mathf.FloorToInt(remainingTime % 60);
            time.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            End();
        }
    }
    public void End()
    {
       if(remainingTime <= 0)
        {
            time.text = "00:00";
            Debug.Log("Game Over Time");
            StartCoroutine(Death());
        }
    }
    private IEnumerator Death()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(4);
    }
}
