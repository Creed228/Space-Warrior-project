using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoController : MonoBehaviour
{
    public GameObject TextObject;
    Text textComponent;
    public int ammo;
    void Start()
    {  
        textComponent = TextObject.GetComponent<Text>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ammo")
        {
            ammo++;
            textComponent.text = ammo.ToString();
            Destroy(other.gameObject);
        }
    }
}
