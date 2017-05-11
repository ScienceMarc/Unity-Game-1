using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class DisablePost : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Disable Post Processes"))
        {
            player.GetComponent<PostProcessingBehaviour>().enabled = !player.GetComponent<PostProcessingBehaviour>().enabled;
        }
	}
}
