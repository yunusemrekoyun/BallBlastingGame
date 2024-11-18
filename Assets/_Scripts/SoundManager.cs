using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    
    private AudioSource audioManager;
    public AudioClip ballHit;

    // Use this for initialization
    void Start() {
        audioManager = GetComponent<AudioSource>();
    }
    
    public void HitSound() {
        audioManager.PlayOneShot(ballHit);
    }
}
