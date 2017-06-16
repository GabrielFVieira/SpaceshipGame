using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour {
    public GameObject player;
    public float speed;
	// Use this for initialization
	void Start () {
        speed = 1.5f;
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.x < transform.position.x + 3 && Time.timeScale == 1)
        {
            if (player.transform.position.y > transform.position.y)
                transform.Translate(0, speed * Time.deltaTime, 0);

            if (player.transform.position.y < transform.position.y)
                transform.Translate(0, -speed * Time.deltaTime, 0);
        }
    }
}
