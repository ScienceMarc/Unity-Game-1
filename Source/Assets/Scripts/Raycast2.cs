using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast2 : MonoBehaviour {

    //Declairing variables
    public GameObject enemyhealth;
    public int dammage;
    public bool fire;
    public int ammo;
    public bool reloading;
    public int capacity;

    void Start()
    {
        //Dammage variable
        capacity = 20;
        dammage = 10;
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
                    if (Input.GetButton("FireGun"))
                    {

                        fire = false;
                        StartCoroutine(WaitRoutine());
                        AudioSource sound = gameObject.GetComponent<AudioSource>();
                        sound.Play();
                        ammo--;


                        if (Physics.Raycast(transform.position, (forward), out hit))
                        {
                            Distance = hit.distance;

                            Debug.Log(Distance + " " + hit.collider.gameObject.name);
                            if (Distance <= 20)
                            {
                                if (hit.collider.gameObject.name == "Enemy") { enemyhealth.GetComponent<Enemy>().enemyhealth -= dammage; Debug.Log("Hit Enemy"); }

                            }

                        }



                    }
                }

            }
        }

        if (ammo <= 0)
        {
            
            StartCoroutine(Reload());
        }

        if (Input.GetButtonDown("Reload"))
        {
            
            StartCoroutine(Reload());
        }






    }

    IEnumerator WaitRoutine()
    {
        yield return new WaitForSeconds(0.15f);
        fire = true;
    }

    IEnumerator Reload()
    {
        reloading = true;
        yield return new WaitForSeconds(1f);
        ammo = capacity;
        reloading = false;
    }
}
