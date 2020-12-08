using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]

public class ParallaxEffect : MonoBehaviour
{
    private float length;
    private float startpos;
    public float EfectoParallax;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (Camera.main.transform.position.x * (1 - EfectoParallax));
        float dist = (Camera.main.transform.position.x * EfectoParallax);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length)
        {
            startpos += length;
        } else if (temp < startpos - length)
        {
            startpos -= length;
        }
    }
}
