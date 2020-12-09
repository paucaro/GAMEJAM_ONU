using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instrucciones : MonoBehaviour
{
    public Image img;
    public Sprite sp_1;
    public Sprite sp_2;
    public SpriteRenderer SR;
    public Animator anim;
    public bool sprite;
  

    public void Start()
    {
        img.GetComponent<Image>().sprite = sp_1;
        anim.GetComponent<Animator>();
        Item.instance.speed = 0;
        Timer.instance.RunTimer = false;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            img.GetComponent<Image>().sprite = sp_2;
            StartCoroutine("March");
        }
        if (sprite == true)
        {
            Marcha();
        }


    }
    public void Marcha()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            anim.SetTrigger("Game");
        }
    }
    public void GameStart()
    {
        Item.instance.speed = 5;
        Timer.instance.RunTimer = true;
        Destroy(gameObject);
    }
    private IEnumerator March()
    {
        yield return new WaitForSeconds(1);
        sprite = true;
    }
}
