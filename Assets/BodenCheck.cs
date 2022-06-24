using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodenCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.parent.GetComponent<PlayerMovement>().isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        transform.parent.GetComponent<PlayerMovement>().isGrounded = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
