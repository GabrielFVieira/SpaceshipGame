using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public GameObject player;
    public float velocity = 0.1f;
    public GameObject characters;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        transform.position = new Vector3(player.transform.position.x + 1.5f, player.transform.position.y, transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        characters = GameObject.Find("Characters");

        if (Time.timeScale == 0 && characters.transform.childCount == 0)
            Destroy(gameObject);

        if(Time.timeScale == 1)
        transform.Translate(velocity, 0, 0);

        if (transform.position.x > 8)
            Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Boss")
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "BossShield")
        {
            Destroy(gameObject);
        }
    }
}
