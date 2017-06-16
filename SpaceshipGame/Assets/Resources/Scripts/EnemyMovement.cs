using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public GameObject player;
    public float velocity = 0.5f;
    public GameObject Left;
    public GameObject Right;
    public GameObject enemyBulletPrefab;
    public float time;
    public int score;
    public int pointsKill = 100;
    public Score gameManager;
    public GameObject characters;

    public GameObject tripleBulletPrefab;
    public GameObject rapidFirePrefab;
    public GameObject forceShieldPrefab;

    public bool kill;

    public int random;
    // Use this for initialization
    void Start () {
        kill = false;
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<Score>();
        
    }
	
	// Update is called once per frame
	void Update () {
        if(random == 1)
        {
            GameObject tripleBullet = Instantiate(tripleBulletPrefab) as GameObject;
            tripleBullet.transform.position = transform.position;
            Destroy(gameObject);
        }

        else if (random == 2)
        {
            GameObject rapidFire = Instantiate(rapidFirePrefab) as GameObject;
            rapidFire.transform.position = transform.position;
            Destroy(gameObject);
        }

        else if (random == 3)
        {
            GameObject forceShield = Instantiate(forceShieldPrefab) as GameObject;
            forceShield.transform.position = transform.position;
            Destroy(gameObject);
        }

        if (kill == true)
            Destroy(gameObject);

        time += Time.deltaTime;

        characters = GameObject.Find("Characters");

        if (Time.timeScale == 0 && characters.transform.childCount == 0)
            Destroy(gameObject);

        if(Time.timeScale == 1)
        transform.Translate(velocity, 0, 0);

        if (time > 1.5f)
        {
            GameObject EnemyBullet = Instantiate(enemyBulletPrefab) as GameObject;
            EnemyBullet.transform.position = new Vector2(transform.position.x - 1f, transform.position.y);
            time = 0;
        }

        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }
      
        if (collision.gameObject.tag == "Bullet")
        {
            random = Random.Range(0, 20);
            kill = true;
            gameManager.score += pointsKill;
        }
    }
}
