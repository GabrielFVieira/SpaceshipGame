using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float velocity = 0.1f;

    public bool andarDir = false;
    public bool andarEsq = false;
    public bool andarCima = false;
    public bool andarBaixo = false;

    public bool BlockandarDir = false;
    public bool BlockandarEsq = false;
    public bool BlockandarCima = false;
    public bool BlockandarBaixo = false;

    public GameObject deathMenu;

    // Use this for initialization
    void Start () {
        velocity = 0.1f;
        deathMenu = GameObject.Find("DeathMenu");
        deathMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale != 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (BlockandarEsq == false)
                    andarEsq = true;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (BlockandarDir == false)
                    andarDir = true;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if(BlockandarCima == false)
                    andarCima = true;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (BlockandarBaixo == false)
                    andarBaixo = true;
            }

            /////////////////////////////////////////////

            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                andarEsq = false;
            }

            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                andarDir = false;
            }

            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                andarCima = false;
            }

            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                andarBaixo = false;
            }

            if (andarEsq == true)
            {
                transform.Translate(-velocity, 0, 0);
            }

            if (andarDir == true)
            {
                transform.Translate(velocity, 0, 0);
            }

            if (andarCima == true)
            {
                transform.Translate(0, velocity, 0);
            }

            if (andarBaixo == true)
            {
                transform.Translate(0, -velocity, 0);
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(this.gameObject);
            deathMenu.SetActive(true);
            Time.timeScale = 0;
        }

        if (collision.gameObject.name == "Up")
        {
            BlockandarCima = true;
        }

        if (collision.gameObject.name == "Down")
        {
            BlockandarBaixo = true;
        }

        if (collision.gameObject.name == "Left")
        {
            BlockandarEsq = true;
        }

        if (collision.gameObject.name == "Right")
        {
            BlockandarDir = true;
        }

    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Up")
        {
            BlockandarCima = false;
        }

        if (collision.gameObject.name == "Down")
        {
            BlockandarBaixo = false;
        }

        if (collision.gameObject.name == "Left")
        {
            BlockandarEsq = false;
        }

        if (collision.gameObject.name == "Right")
        {
            BlockandarDir = false;
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            deathMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
