using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPowerUps : MonoBehaviour {
    public Bullet bullet;
    public Shoot shoot;

    public GameObject shield;

    public float maxTime;

    public bool timerTactive;
    public bool timerRactive;
    public float timerT;
    public float timerR;

	// Use this for initialization
	void Start () {
        maxTime = 5;
        timerTactive = timerRactive = false;
        shield = GameObject.Find("PlayerShield");
        shield.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (timerRactive == false)
            bullet.velocity = 0.1f;

		if(timerTactive == true)
        {
            timerT += Time.deltaTime;
            shoot.maxBullet = 9;
            shoot.tripleFire = true;

            if(timerT > maxTime)
            {
                shoot.maxBullet = 5;
                shoot.tripleFire = false;
                timerT = 0;
                timerTactive = false;
            }
        }

        if (timerRactive == true)
        {
            timerR += Time.deltaTime;
            bullet.velocity = 0.2f;
            shoot.maxBullet = 8;

            if (timerR > maxTime)
            {
                bullet.velocity = 0.1f;
                shoot.maxBullet = 5;
                timerR = 0;
                timerRactive = false;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "TripleFire")
        {
            timerTactive = true;
        }

        if (collision.gameObject.tag == "ForceShield")
        {
            shield.SetActive(true);
        }

        if (collision.gameObject.tag == "RapidFire")
        {
            timerRactive = true;
        }
    }
}
