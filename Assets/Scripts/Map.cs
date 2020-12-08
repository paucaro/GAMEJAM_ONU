using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    // Test
    float seconds = 10;
    float timer;

    // Variables
    public float percent;
    
    Vector3 start;
    Vector3 startPos;
    Vector3 finalPos;
    Vector3 diferencia;

    void Start()
    {
        start = transform.localPosition;
        startPos = GameObject.FindGameObjectWithTag("inicioMap").transform.localPosition;
        finalPos = GameObject.FindGameObjectWithTag("finalMap").transform.localPosition;
        diferencia = finalPos - startPos;
    }

    void Update()
    {
        if (timer <= seconds) {
            // Test
            timer += Time.deltaTime;
            percent = timer / seconds;
            // Magic logic
            transform.localPosition = start + diferencia * percent;
        }
    }
}
