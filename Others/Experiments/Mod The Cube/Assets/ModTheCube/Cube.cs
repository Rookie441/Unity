using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    
    void Start()
    {
        transform.position = new Vector3(0, 5, 0);
        transform.localScale = Vector3.one * 1.3f;
        
        Material material = Renderer.material;
        
        material.color = new Color(0.0f, 3.0f, 0.0f, 1.0f);
    }
    
    void Update()
    {
        transform.Rotate(50.0f * Time.deltaTime, 30.0f * Time.deltaTime, 0.0f);
    }
}
