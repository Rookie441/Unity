using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public KeyCode switchKey; //use "F" to change view for left player, use "Right Shift" to change view for right player

    private bool fpsView = false;
    private Vector3 offset = new Vector3(0, 8, -20);
    private Vector3 perspective = new Vector3(0, 3, -1);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyUp(switchKey))
        {
            fpsView = !fpsView;
        }
        transform.position = player.transform.position + (fpsView ? offset : perspective);

    }
}
