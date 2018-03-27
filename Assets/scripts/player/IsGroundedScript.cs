using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGroundedScript : MonoBehaviour {

    public AudioClip SoundGround;

    private AudioSource Audio;

    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }
	
	void OnTriggerEnter2D (Collider2D collider) {
        transform.parent.GetComponent<PlayerController>().isGrounded = true;
        Audio.PlayOneShot(SoundGround);
	}

    void OnTriggerExit2D(Collider2D collider)
    {
        transform.parent.GetComponent<PlayerController>().isGrounded = false;
    }
}
