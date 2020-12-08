using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public static Enemy instance;
    public Animator anim;
    public Slider slider;

    [Header("Tipo de Enemigo")]
    public bool enemy_1;
    public bool enemy_2;
    public bool enemy_3;
    public bool myPlayer;
    public bool attacked;
    public int life;
    public int damage;
    [Header("Tipo de Enemigo")]
    public bool argumentar, ignorar, aliados, gas, golpe, llaves;
    public Slider myHealth;
    public void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        if (enemy_1)
        {
            life = 10; 
        }
        if (enemy_2)
        {
            life = 20; 
        }
        if (enemy_3)
        {
            life = 30;
        }
        slider.maxValue = life;
        slider.value = life;
    }
    public void Update()
    {
        Health();
        if (attacked == false)
        {
            Injured();
            Debug.Log(life);
        }

        if(life <= 0)
        {
            Debug.Log("Im dead");
            myPlayer = false;
            anim.SetTrigger("death");
            Item.instance.enemySighted_1 = false;
            Item.instance.enemySighted_2 = false;
            Item.instance.enemySighted_3 = false;
        }
    }
    public void DestroyMe()
    {
        Destroy(gameObject);
    }
    public void Injured()
    {
        //Ignorar
        if (Input.GetKeyDown(KeyCode.A) && myPlayer)
        {
            if (enemy_1)
            {
                damage = 5;
            }
            if (enemy_2)
            {
                damage = 3;
            }
            if (enemy_3)
            {
                damage = 1;
            }
            life = life - damage;
            attacked = true;
            StartCoroutine(coolDown());
        }
        //Argumentar
        if (Input.GetKeyDown(KeyCode.S) && myPlayer)
        {
            if (enemy_1)
            {
                damage = 5;
            }
            if (enemy_2)
            {
                damage = 3;
            }
            if (enemy_3)
            {
                damage = 1;
            }
            life = life - damage;
            attacked = true;
            StartCoroutine(coolDown());
        }
        //Aliados
        if (Input.GetKeyDown(KeyCode.D) && myPlayer)
        {
            if (enemy_1)
            {
                Debug.Log("GameOver");
                StartCoroutine(Death());
                damage = 0;
            }
            if (enemy_2)
            {
                Debug.Log("GameOver");
                StartCoroutine(Death());
                damage = 0;
            }
            if (enemy_3)
            {
                damage = 12;
            }
            life = life - damage;
            attacked = true;
            StartCoroutine(coolDown());
        }
        //Llaves
        if (Input.GetKeyDown(KeyCode.F) && myPlayer)
        {
            if (enemy_1)
            {
                Debug.Log("GameOver");
                StartCoroutine(Death());
                damage = 0;
            }
            if (enemy_2)
            {
                damage = 7;
            }
            if (enemy_3)
            {
                damage = 3;
            }
            life = life - damage;
            attacked = true;
            StartCoroutine(coolDown());
        }
        //Gas Pimienta
        if (Input.GetKeyDown(KeyCode.G) && myPlayer)
        {
            if (enemy_1)
            {
                Debug.Log("GameOver");
                StartCoroutine(Death());
                damage = 0;
            }
            if (enemy_2)
            {
                damage = 7;
            }
            if (enemy_3)
            {
                damage = 3;
            }
            life = life - damage;
            attacked = true;
            StartCoroutine(coolDown());
        }
        //Golpe
        if (Input.GetKeyDown(KeyCode.H) && myPlayer)
        {
            if (enemy_1)
            {
                Debug.Log("GameOver");
                StartCoroutine(Death());
                damage = 0;
            }
            if (enemy_2)
            {
                Debug.Log("GameOver");
                StartCoroutine(Death());
                damage = 0; 
            }
            if (enemy_3)
            {
                damage = 12;
            }
            life = life - damage;  
            attacked = true;
            StartCoroutine(coolDown());
        }
    }
    public void Health()
    {
        slider.value = life;
    }
    public void GameOver()
    {
        SceneManager.LoadScene(3);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            myPlayer = true;
        }
    }
    private IEnumerator coolDown()
    {
        yield return new WaitForSeconds(1);
        attacked = false;
    }
    private IEnumerator Death()
    {
        yield return new WaitForSeconds(1);
        GameOver();
    }
}
