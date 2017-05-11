using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour {

    public int health = 100;
    public int weapon;


    public GameObject Gun1;
    public GameObject Gun2;
    public GameObject Gun3;
    public GameObject Gun1Raycast;
    public GameObject Gun2Raycast;
    public GameObject Gun3Raycast;
    


	// Use this for initialization
	void Start () {
        
        Gun2.SetActive(false);
        Gun3.SetActive(false);

        weapon = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            Debug.Log("Player death");
            Application.LoadLevel("Death");
            
        }

        if (Input.GetButtonDown("GunSelect2"))
        {
            weapon = 2;
            StartCoroutine(Gun2pullout());
            
            
        }
        else if (Input.GetButtonDown("GunSelect1"))
        {
            weapon = 1;
            StartCoroutine(Gun1pullout());
            
        }
        if (Input.GetButtonDown("GunSelect3"))
        {
            weapon = 3;
            StartCoroutine(Gun3pullout());
        }
	}

    IEnumerator Gun1pullout()
    {
        Gun2.SetActive(false);
        Gun1.SetActive(true);
        Gun3.SetActive(false);
        Gun1Raycast.GetComponent<Raycast1>().fire = false;
        
        yield return new WaitForSeconds(0.5f);
        Gun1Raycast.GetComponent<Raycast1>().fire = true;

    }

    IEnumerator Gun2pullout()
    {
        Gun2.SetActive(true);
        Gun1.SetActive(false);
        Gun3.SetActive(false);
        Gun2Raycast.GetComponent<Raycast2>().reloading = false;
        Gun2Raycast.GetComponent<Raycast2>().fire = false;
        yield return new WaitForSeconds(0.6f);
        Gun2Raycast.GetComponent<Raycast2>().fire = true;

    }

    IEnumerator Gun3pullout()
    {
        Gun2.SetActive(false);
        Gun1.SetActive(false);
        Gun3.SetActive(true);
        Gun3Raycast.GetComponent<Raycast3>().reloading = false;
        Gun3Raycast.GetComponent<Raycast3>().fire = false;
        yield return new WaitForSeconds(1f);
        Gun3Raycast.GetComponent<Raycast3>().fire = true;
    }
}
