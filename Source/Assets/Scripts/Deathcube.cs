﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathcube : MonoBehaviour {

    public GameObject health;

    


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Death Cube collision");
            health.GetComponent<PlayerScripts>().health = 0;
        }
    }
}
