using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public GameObject bulletPrefab;
    public int maxBullet;
    public bool tripleFire;
	// Use this for initialization
	void Start () {
        maxBullet = 5;
        tripleFire = false;
    }
	
	// Update is called once per frame
	void Update () {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");

        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale != 0)
        {
            if (bullets.Length < maxBullet)
            {
                if (tripleFire == true)
                {
                    GameObject bullet = Instantiate(bulletPrefab) as GameObject;
                    GameObject bulletCima = Instantiate(bulletPrefab) as GameObject;
                    bulletCima.transform.Rotate(0, 0, 45);
                    GameObject bulletBaixo = Instantiate(bulletPrefab) as GameObject;
                    bulletBaixo.transform.Rotate(0, 0, -45);
                }

                else
                {
                    GameObject bullet = Instantiate(bulletPrefab) as GameObject;
                }
            }
        }
	}
}
