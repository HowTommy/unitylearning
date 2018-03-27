using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // déclaration de variables
    // si public : accessible depuis l'inspector !
    public int speed = 7;
    public int jump = 300;
    public bool isGrounded = false;
    public AudioClip soundJump;
    public AudioClip soundDead;
    public bool IsDead;

    private bool isJumping = false;

    private AudioSource audio;

    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        IsDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsDead)
        {
            return;
        }

        float h = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * h * speed * Time.deltaTime);

        if (h != 0)
        {
            anim.SetBool("IsWalking", true);
            GetComponent<SpriteRenderer>().flipX = h < 0 ? true : false;
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            playerDead();
        }
    }

    // Se déclenche à un temps donné
    void FixedUpdate()
    {
        if (IsDead)
        {
            return;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            audio.PlayOneShot(soundJump);
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jump * Time.deltaTime;
            anim.SetTrigger("Jumps");
            anim.SetBool("IsWalking", false);
        }
    }

    public void playerDead()
    {
        anim.SetTrigger("Dies");
        audio.PlayOneShot(soundDead);
        IsDead = true;
    }
}
