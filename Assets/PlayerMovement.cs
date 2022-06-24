using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rig;
    float speed = 80;
    float jumpforce = 5f;
    public bool isGrounded = false;
    float maxSideways = 3f;
    Vector2 movement = new Vector2(0, 0);
    bool isJumping = false;
    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false;
        isJumping = false;
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(0, 0);
        /*
        if (isGrounded)
            rig.gravityScale = 0;
        else
            rig.gravityScale = 1;
        */
        if(isGrounded && Input.GetKey(KeyCode.UpArrow))
        {
            isJumping = true;
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
        /*
        if (rig.velocity.magnitude < 20)
            rig.velocity += movement*speed*Time.deltaTime;
        */
        
        
        //Debug.Log(rig.velocity.magnitude);
    }

    private void FixedUpdate()
    {
        if(isJumping)
        {
            rig.AddForce(Vector2.up*jumpforce, ForceMode2D.Impulse);
            isJumping = false;
            isGrounded = false;
        }
        rig.velocity += movement * speed * Time.deltaTime;
        
        if (rig.velocity.x > maxSideways)
            rig.velocity = new Vector2(maxSideways, rig.velocity.y);
        if (rig.velocity.x < -maxSideways)
            rig.velocity = new Vector2(-maxSideways, rig.velocity.y);
        
        
    }


}
