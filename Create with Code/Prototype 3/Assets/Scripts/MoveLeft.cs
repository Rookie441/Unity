using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float leftBound = -15;
    private float speed = 10;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            if (!playerControllerScript.isDash)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
            else
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed * 2); // dash is 2 times faster
            }
            
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        
    }
}
