using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour {


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
            //EXTERMINATE!
            Debug.Log("OUT OF BOUNDS! KILLING PLAYER!");
            health.GetComponent<PlayerScripts>().health = 0;
        }
    }
}
