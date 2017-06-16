using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShield : MonoBehaviour {
    public BossAI boss;

    public int life = 5;

	// Use this for initialization
	void Start () {
        life = 5;
	}
	
	// Update is called once per frame
	void Update () {
        if (life == 0)
        {
            gameObject.SetActive(false);
        }
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            life -= 1;
        }
    }

}
