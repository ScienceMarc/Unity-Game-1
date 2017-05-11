using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject self;
    public bool rotdirection;
    public int enemyhealth = 100;
    public GameObject Player;
    public bool engaged = false;
    public bool rotate = false;
    // Use this for initialization
    void Start()
    {
        rotdirection = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyhealth <= 0)
        {
            self.SetActive(false);
        }
        



        


        //Hit player
        if (engaged == false)
        {
            StartCoroutine(damage());
            
        }
        if (rotate == false)
        {
            StartCoroutine(rotation());
        }
        

        //Rudimentary AI. Could use improving

       
        
    }

    //Does dammage and waits
    IEnumerator damage()
    {
        engaged = true;
        yield return new WaitForSeconds(0.1f);
        RaycastHit hit;
        float Distance;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
        
        if (Physics.Raycast(transform.position, (forward), out hit))
        {
            Distance = hit.distance;


            if (Distance <= 10)
            {
                
                if (hit.collider.gameObject.name == "FPSController") {  Player.GetComponent<PlayerScripts>().health = Player.GetComponent<PlayerScripts>().health - 1;  }
            }

        }

        engaged = false;
    }

    IEnumerator rotation()
    {
        rotate = true;
        yield return new WaitForSeconds(0.01f);
        RaycastHit hit;
        float Distance;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
        if (rotdirection == true)
        {
            transform.Rotate(0, 3, 0);
            if (Physics.Raycast(transform.position, (forward), out hit))
            {
                Distance = hit.distance;
                if (Distance <= 10)
                {
                    Debug.Log(hit);
                    if (hit.collider.gameObject.name == "FPSController") { rotdirection = false; yield return new WaitForSeconds(0.1f); transform.Translate(forward*Time.deltaTime*5, Space.Self); }
                }

            }
        }
        if (rotdirection == false)
        
        {
            transform.Rotate(0, -3, 0);
            if (Physics.Raycast(transform.position, (forward), out hit))
            {
                Distance = hit.distance;


                if (Distance <= 10)
                {
                    if (hit.collider.gameObject.name == "FPSController") { rotdirection = true; }
                }

            }
        }
        rotate = false;
    }
}