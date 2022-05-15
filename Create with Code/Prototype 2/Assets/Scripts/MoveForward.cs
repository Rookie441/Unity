using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float speed = 8.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy object if it travels too far
        //if (transform.position.magnitude > 50.0f)
            //Destroy(gameObject);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
    }
}
