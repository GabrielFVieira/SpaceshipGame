using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour {
    public float velocityX;
    public float velocityY;
    public bool sobe;

    public GameObject healthBar;
    public GameObject shield;

    public BossShield bossShield;

    public float life;
    public float maxLife;
    public GameObject winMenu;

    public GameObject player;
    public GameObject enemyBulletPrefab;
    public float time;
    public GameObject characters;

    public bool controle = true;

    public bool uniBeam = false;
    public bool uniBeamControl = true;
    // Use this for initialization
    void Start () {
        winMenu = GameObject.Find("WinMenu");
        winMenu.SetActive(false);

        shield = GameObject.Find("Shield");
        shield.SetActive(false);

        life = 20;
        maxLife = life;
        velocityX = 2.5f;
        velocityY = 1.5f;
        sobe = true;

        bossShield.life = 5;
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        characters = GameObject.Find("Characters");

        if (Time.timeScale == 0 && characters.transform.childCount == 0)
            Destroy(gameObject);


        if (Time.timeScale == 1)
        {

            if (time > 1f && transform.position.x < 5.5f)
            {
                if (uniBeam == false)
                {
                    GameObject EnemyBullet = Instantiate(enemyBulletPrefab) as GameObject;
                    EnemyBullet.transform.position = new Vector2(transform.position.x - 3f, transform.position.y + 0.5f);
                    EnemyBullet.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

                    GameObject EnemyBulletCima = Instantiate(enemyBulletPrefab) as GameObject;
                    EnemyBulletCima.transform.Rotate(0, 0, 45);
                    EnemyBulletCima.transform.position = new Vector2(transform.position.x - 3f, transform.position.y + 0.5f);
                    EnemyBulletCima.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);


                    GameObject EnemyBulletBaixo = Instantiate(enemyBulletPrefab) as GameObject;
                    EnemyBulletBaixo.transform.Rotate(0, 0, -45);
                    EnemyBulletBaixo.transform.position = new Vector2(transform.position.x - 3f, transform.position.y + 0.5f);
                    EnemyBulletBaixo.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                }

                else
                {
                    GameObject EnemyBulletG = Instantiate(enemyBulletPrefab) as GameObject;
                    EnemyBulletG.transform.position = new Vector2(transform.position.x - 3f, transform.position.y + 0.5f);
                    EnemyBulletG.transform.localScale = new Vector3(0.5f, 0.5f, 0.2f);
                    uniBeam = false;
                }

                time = 0;
            }

            if (transform.position.x < -10)
            {
                Destroy(gameObject);
            }


            if (life == 15 && bossShield.life == 5)
            {
                shield.SetActive(true);
            }

            if (life == 10 && uniBeamControl == true)
            {
                uniBeam = true;
                uniBeamControl = false;
            }

            if (life == 5 && controle == true)
            {
                shield.SetActive(true);
                bossShield.life = 5;
                controle = false;
            }

            if (life == 0)
            {
                Destroy(gameObject);
                winMenu.SetActive(true);
                Time.timeScale = 0;
            }

            if (transform.position.x > 5.5f)
                transform.Translate(velocityX * Time.deltaTime, 0, 0);

            if (transform.position.x < 5.5f)
            {
                if (transform.position.y < 2.7 && sobe == true)
                {
                    transform.Translate(0, velocityY * Time.deltaTime, 0);
                }

                else
                {
                    sobe = false;
                }

                if (transform.position.y > -3.25 && sobe == false)
                {
                    transform.Translate(0, -velocityY * Time.deltaTime, 0);
                }

                else
                {
                    sobe = true;
                }
            }

        } 
    }

    void FixedUpdate()
    {
        float calc_Health = life / maxLife;
        SetHealthBar(calc_Health);
    }

    void SetHealthBar(float myHealth)
    {
        healthBar.transform.localScale = new Vector3(myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if(shield.activeSelf == false)
            life -= 1;
        }
    }
}