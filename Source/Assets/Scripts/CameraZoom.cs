using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {
    public int zoom = 20;
    public int normal = 90;
    public float smooth = 5;
    public GameObject weapon;
    public int weaponval;

    public bool Zoomed = false;

	// Use this for initialization
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
        weaponval = weapon.GetComponent<PlayerScripts>().weapon;
        if (weaponval == 3)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Zoomed = !Zoomed;
            }
            
        }
        else { Zoomed = false; }
        if (Zoomed)
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
        }

        else
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
        }
        if (Input.GetButtonUp("Sprint")) { GetComponent<Camera>().fieldOfView = normal; Zoomed = false; }
    }
}
