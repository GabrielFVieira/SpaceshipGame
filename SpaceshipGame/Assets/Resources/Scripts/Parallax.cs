using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if(Time.timeScale == 1)
        transform.Translate(-0.02f, 0, 0);

        if(transform.position.x <= -18.86f)
        {
            transform.position = new Vector3(18.86f, transform.position.y, transform.position.z);
        }

    }
}
