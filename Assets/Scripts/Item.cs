﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Item : MonoBehaviour
{
    public static Item instance;
    public Animator anim;
    public float speed;
    public GameObject my_Animation;
    float horizontalInput;
    [Header("Items")]
    public bool defend;
    public int damage;

    [Header("Enemy")]
    public bool enemySighted_1;
    public bool enemySighted_2;
    public bool enemySighted_3;

    public void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        anim = my_Animation.GetComponent<Animator>();
    }
    public void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if(Enemy.instance.attacked == false)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                anim.SetTrigger("ignorar");
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                anim.SetTrigger("argumentar");
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                anim.SetTrigger("aliados");
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                anim.SetTrigger("llaves");
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                anim.SetTrigger("gasP");
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                anim.SetTrigger("golpe");
            }
        }
        Move();
    }
    public void Move()
    {
        if (!enemySighted_1 && !enemySighted_2 && !enemySighted_3)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
    private void Win()
    {
        SceneManager.LoadScene(2);
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "enemy_1")
        {
            enemySighted_1 = true;
            anim.SetTrigger("idle");

        }
        if (col.tag == "enemy_2")
        {
            enemySighted_2 = true;
            anim.SetTrigger("idle");
        }
        if (col.tag == "enemy_3")
        {
            enemySighted_3 = true;
            anim.SetTrigger("idle");
        }
        if (col.tag == "home")
        {
            Win();
        }
    }
}