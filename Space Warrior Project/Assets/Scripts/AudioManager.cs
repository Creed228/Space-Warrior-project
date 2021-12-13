using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    [SerializeField] private AudioSource fx;
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private AudioClip clickSound;

    public static AudioManager instance;

    private void Start()
    {
        instance = this;
    }

    public void AttackSound()
    {
        fx.PlayOneShot(attackSound);
    }

    public void ClickSound()
    {
        fx.PlayOneShot(clickSound);
    }
}
