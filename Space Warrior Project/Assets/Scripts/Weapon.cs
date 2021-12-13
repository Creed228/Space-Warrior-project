using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bullet;
    public int ammo;
    public GameObject TextObject;
    Text textComponent;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammo > 0)
        {
            Shoot();
            ammo--;
            textComponent.text = ammo.ToString();
        }
    }

    void Shoot() {
        if(FindObjectOfType<GameController>().gameActive) {
            AudioManager.instance.AttackSound();
            Instantiate(bullet, FirePoint.position, FirePoint.rotation);
        }
    }

    void Start()
    {
        textComponent = TextObject.GetComponent<Text>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ammo")
        {
            AudioManager.instance.ClickSound();
            ammo ++;
            textComponent.text = ammo.ToString();
            Destroy(other.gameObject);
        }
    }          
}
