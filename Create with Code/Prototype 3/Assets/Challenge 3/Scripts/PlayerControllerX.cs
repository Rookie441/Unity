using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;
    private float upperBound = 14.3f;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bounceSound;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver && transform.position.y < upperBound - 5.0f) //add offset so player cannot float at high position
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }

        // Prevent player from floating the balloon too high
        if (transform.position.y > upperBound)
        {
            transform.position = new Vector3(transform.position.x, upperBound, transform.position.z);
            playerRb.AddForce(Vector3.down * floatForce);
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
            Destroy(gameObject, 1.5f); //Destroy balloon after 1.5seconds
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

        // if player collides with ground, prevent balloon from dropping below ground, add a weak "bounce" effect
        else if (other.gameObject.CompareTag("Ground") && !gameOver)
        {
            playerAudio.PlayOneShot(bounceSound, 1.0f);
            playerRb.AddForce(Vector3.up * (floatForce * 10));
        }

    }

}
