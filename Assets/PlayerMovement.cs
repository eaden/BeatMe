using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rig;
    float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(0,0);
        if(Input.GetKey(KeyCode.UpArrow))
        {
            movement.y = 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movement.y = -1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement.x = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movement.x = 1;
        }

        rig.velocity += movement*speed*Time.deltaTime;
    }
}
