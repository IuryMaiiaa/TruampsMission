﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawDestroier : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "tijolo")
        {
            coll.gameObject.GetComponent<Tijolo>().tijoloDestruction();
        }
            

    }
}
