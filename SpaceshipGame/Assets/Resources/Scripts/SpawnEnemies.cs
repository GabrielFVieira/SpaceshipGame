using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {
    public GameObject enemyPrefab;
    public GameObject enemyWavePrefab;
    public GameObject enemyFollowPrefab;

    public GameObject terra;
    public GameObject sol;

    public GameObject boss;

    public float random;
    public int contador;
    public float delta;

    public bool controle = true;
    public bool bossActive = false;

    public int position;

    public int i;
    public int delay;
    public int count;

    public int randomWave;
    // Use this for initialization
    void Start () {
        i = 8;
        delay = 5;
        boss.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
        contador++;

        if (delta > 15 && delta < 15.1f)
        {
            GameObject earth = Instantiate(terra) as GameObject;
        }

        if (random == 0)
            position = 0;

        if (random == 1)
            position = 3;

        if (random == 2)
            position = -3;

        delta += Time.deltaTime;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (delta < 80)
        {
            if (enemies.Length < 5 && contador == 60 && count < 5)
            {
                if (randomWave == 0)
                {
                    Spawn();
                }
                if (randomWave == 2)
                {
                    Spawn3();
                }
                count++;
                contador = 0;
            }

            if (delta > i && delta < i + 0.1f)
            {
                randomWave = Random.Range(0, 3);
                if (randomWave == 1)
                {
                    Spawn2();
                }
                if (controle == true && randomWave != 1)
                {
                    count = 0;
                    contador = 0;
                    random = Random.Range(0, 3);
                    controle = false;
                }

                controle = true;
                i += delay;
            }

            if (delta > 30)
                delay = 4;

            if (delta > 50)
                delay = 3;

            if (delta > 70)
                delay = 2;
            /*
            if (delta > i && delta < i + 1 && controle == true)
            {
                Spawn2();
                controle = false;
            }*/

            /*
            else if (delta > i && delta < i + 1)
            {
                count = 0;
                contador = 0;
                random = Random.Range(0, 3);

                i += 5;
            }

            else if (delta > i && delta < i + 1)
            {
                count = 0;
                contador = 0;
                random = Random.Range(0, 3);

                i += 5;
            }

            else if (delta > i && delta < i + 1)
            {
                count = 0;
                contador = 0;
                random = Random.Range(0, 3);

                i += 5;
            }
            */
        }

        if(delta > 85 && bossActive == false)
        {
            boss.SetActive(true);
            bossActive = true;
        }
    }
    public void Spawn()
    {
       GameObject enemy = Instantiate(enemyPrefab) as GameObject;
       enemy.transform.position = new Vector2(10.3f, position);
    }

    public void Spawn2()
    {
        GameObject enemyWave = Instantiate(enemyWavePrefab) as GameObject;
    }

    public void Spawn3()
    {
        GameObject enemyFollow = Instantiate(enemyFollowPrefab) as GameObject;
    }
}
