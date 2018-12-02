using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    [SerializeField]
    int health = 10;
    [SerializeField]
    int healthDecrease = 1;
    [SerializeField]
    Text healthText;
    // Use this for initialization
    [SerializeField]
    AudioClip takeDamageSFX;
    void Start () {
        healthText.text = health.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        health-= healthDecrease;
        healthText.text = health.ToString();
        GetComponent<AudioSource>().PlayOneShot(takeDamageSFX);
        if (health <= 0) {
            //lose the game
        }
    }
}
