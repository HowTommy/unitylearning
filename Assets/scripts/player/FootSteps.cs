using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour {

    public AudioClip SoundFootSteps;

    private AudioSource Audio;

    public float PitchMin = 3f;
    public float PitchMax = 4f;
    public float VolMin = 0.3f;
    public float VolMax = 0.6f;

	// Use this for initialization
	void Start () {
        Audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetAxis("Horizontal") != 0 && !Audio.isPlaying && transform.parent.GetComponent<PlayerController>().isGrounded)
        {
            Audio.pitch = Random.Range(PitchMin, PitchMax);
            Audio.volume = Random.Range(VolMin, VolMax);
            Audio.PlayOneShot(SoundFootSteps);
        }
	}
}
