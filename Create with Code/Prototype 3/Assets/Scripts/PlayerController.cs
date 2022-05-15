using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool gameOver = false;

    private Rigidbody playerRB;
    private Animator playerAnim;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    public float jumpForce;
    public float gravityModifier;

    private int jumpCounter = 2;
    public bool isDash = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && jumpCounter >=1)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAudio.PlayOneShot(jumpSound, 0.8f);
            dirtParticle.Stop();
            playerAnim.SetTrigger("Jump_trig");
            jumpCounter--;
        }

        // Add Dash ability
        if (Input.GetKeyDown(KeyCode.F) && !gameOver)
        {
            //playerAnim.speed = 2.0f;
            playerAnim.SetFloat("Speed_f", 2.0f);
            isDash = true;
        }

        if (Input.GetKeyUp(KeyCode.F) && !gameOver)
        {
            //playerAnim.speed = 1.0f;
            playerAnim.SetFloat("Speed_f", 1.0f);
            isDash = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            dirtParticle.Play();
            jumpCounter = 2;
        } else if (collision.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAudio.PlayOneShot(crashSound, 0.6f);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
        
    }
}
