using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    // Awake is called immediately when the object is created (when Instantiate is called)
    void Awake() 
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy gameObject if it goes too far out of the map
        if (transform.position.magnitude > 1000.0f) 
        {
            Destroy(gameObject);
        }
    }
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        BotController e = other.collider.GetComponent<BotController>();
        if (e != null)
        {
            e.Fix();
        }

        Destroy(gameObject);
    }
}
