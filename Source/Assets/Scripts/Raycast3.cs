using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast3 : MonoBehaviour {

    //Declairing variables
    public GameObject enemyhealth;
    public bool fire;
    public int dammage;
    public int ammo;
    public bool reloading;
    public int capacity;


    void Start()
    {
        //Dammage variable
        capacity = 10;
        dammage = 100;
        fire = true;
        ammo = capacity;
        reloading = false;
        
    }


    void Update()
    {

        //Raycast setup
        RaycastHit hit;
        float Distance;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);

        //Left click checks if it hits an enemy within range.
        

        if (reloading != true)
        {
            if (ammo >= 1)
            {
                if (fire == true)
                {
                    if (Input.GetButtonDown("FireGun"))
                    {
                        AudioSource sound = gameObject.GetComponent<AudioSource>();
                        sound.Play();
                        fire = false;
                        StartCoroutine(WaitRoutine());
                        ammo--;

                        if (Physics.Raycast(transform.position, (forward), out hit))
                        {
                            Distance = hit.distance;

                            Debug.Log(Distance + " " + hit.collider.gameObject.name);
                            if (Distance <= 100)
                            {
                                if (hit.collider.gameObject.name == "Enemy") { enemyhealth.GetComponent<Enemy>().enemyhealth -= dammage; Debug.Log("Hit Enemy"); }



                            }

                        }


                    }
                }
            }
        }

        if (Input.GetButtonDown("Reload"))
        {
            if (!Input.GetButtonDown("FireGun")) { StartCoroutine(Reload()); }

        }
        if (ammo <= 0)
        {
            StartCoroutine(Reload());
        }

    }

    IEnumerator WaitRoutine()
    {

        yield return new WaitForSeconds(2f);
        fire = true;
    }
    IEnumerator Reload()
    {
        reloading = true;
        yield return new WaitForSeconds(1.5f);
        ammo = capacity;
        reloading = false;
    }
}
