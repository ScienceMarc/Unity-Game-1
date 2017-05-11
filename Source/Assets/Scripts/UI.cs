using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    //Declaring variables
    public Text AmmoText;
    public GameObject Weapon;
    public GameObject Gun1;
    public GameObject Gun2;
    public GameObject Gun3;
    
    public Text HP;
    public int health;
    public int ammo;

	// Use this for initialization
	void Start () {
        //What the text starts off as
        if (Weapon.GetComponent<PlayerScripts>().weapon == 1)
        {
            ammo = Gun1.GetComponent<Raycast1>().ammo;
            AmmoText.text = "Ammo: " + ammo.ToString();
        }
        if (Weapon.GetComponent<PlayerScripts>().weapon == 2)
        {
            ammo = Gun2.GetComponent<Raycast2>().ammo;
            AmmoText.text = "Ammo: " + ammo.ToString();
        }
        if (Weapon.GetComponent<PlayerScripts>().weapon == 3)
        {
            ammo = Gun3.GetComponent<Raycast3>().ammo;
            AmmoText.text = "Ammo: " + ammo.ToString();
        }
        HP.text = "HP: " + health;
    }
	
	
	void Update () {
        //Updates the UI every frame
        if (Weapon.GetComponent<PlayerScripts>().weapon == 1)
        {
            ammo = Gun1.GetComponent<Raycast1>().ammo;
            AmmoText.text = "Ammo: " + ammo.ToString();
            if (Gun1.GetComponent<Raycast1>().ammo <= 0)
            {
                AmmoText.text = "Reload";
            }
        }

        if (Weapon.GetComponent<PlayerScripts>().weapon == 2)
        {
            ammo = Gun2.GetComponent<Raycast2>().ammo;
            AmmoText.text = "Ammo: " + ammo.ToString();
            if (Gun2.GetComponent<Raycast2>().ammo <= 0)
            {
                AmmoText.text = "Reload";
            }
        }

        if (Weapon.GetComponent<PlayerScripts>().weapon == 3)
        {
            ammo = Gun3.GetComponent<Raycast3>().ammo;
            AmmoText.text = "Ammo: " + ammo.ToString();
        }
        health = Weapon.GetComponent<PlayerScripts>().health;
        HP.text = "HP: " + health.ToString();
    }
}
