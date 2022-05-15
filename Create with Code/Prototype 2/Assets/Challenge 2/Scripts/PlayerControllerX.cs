using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    bool cooldown = false;
    float cooldownTimer = 1.0f;

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer < 0)
        {
            cooldown = false;
        }
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!cooldown)
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                cooldown = true;
                cooldownTimer = 1.0f;
            } 
        }
    }
}
