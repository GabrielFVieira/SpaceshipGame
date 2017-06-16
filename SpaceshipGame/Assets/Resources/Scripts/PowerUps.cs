using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {
    public Vector2 velocity;
    public int random;
    // Use this for initialization
    void Start () {
        random = Random.Range(0, 2);
        if(random == 0)
        velocity = new Vector2(-0.05f, 0.05f);

        if (random == 1)
            velocity = new Vector2(-0.05f, -0.05f);
    }
	
	// Update is called once per frame
	void Update () {
        if(Time.timeScale == 1)
        transform.Translate(velocity.x, velocity.y, 0);

        if (transform.position.x < -10)
            Destroy(gameObject);
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.name == "Up")
        {
            velocity.y *= -1;
        }

        if (collision.gameObject.name == "Down")
        {
            velocity.y *= -1;
        }
    }
}
