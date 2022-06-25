using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KugelScript : MonoBehaviour
{
    Rigidbody2D rig;
    Vector2 movement = new Vector2(0, 0);
    float speed = 40;
    float speedLimit = 10;
    bool isHanding = false;
    bool noLimit = false;
    float kickforce = 30;
    float timeLimit = 0.5f;
    float timeLimitLimit = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        isHanding = false;
        noLimit = false;
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(0, 0);
        if(gameObject.name == "Hand")
        {
            if (Input.GetKey(KeyCode.W))
            {
                movement.y = 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                movement.y = -1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                movement.x = -1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                movement.x = 1;
            }
            if (Input.GetKeyDown(KeyCode.Space) && !isHanding && !noLimit)
            {
                isHanding = true;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
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
            if (Input.GetKeyDown(KeyCode.KeypadEnter) && !isHanding && !noLimit)
            {
                isHanding = true;
            }
        }
        
    }
    private void FixedUpdate()
    {
        rig.velocity += movement * speed * Time.deltaTime;
        if(!noLimit)
        {
            if (rig.velocity.magnitude > speedLimit)
            {
                rig.velocity = rig.velocity.normalized * speedLimit;
            }
        }
        else
        {
            if(timeLimit > 0)
            {
                timeLimit -= Time.deltaTime;
            }
            else
            {
                noLimit = false;
                timeLimit = timeLimitLimit; 
            }
        }
        
        if (isHanding)
        {
            rig.AddForce(movement * kickforce, ForceMode2D.Impulse);
            noLimit = true;
            isHanding = false;
        }
    }
}
