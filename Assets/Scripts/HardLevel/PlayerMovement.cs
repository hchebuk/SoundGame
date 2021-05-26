using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float pushforward; //Forward speed
    public float sidepush; //Left and Right speed

    // Start is called before the first frame update
    //Don't need right now but would be cool if our character jumped into the lane at start
    void Start()
    {
        rb.AddForce(0,300f,0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Pushes player forward
        rb.AddForce(0,0,pushforward * Time.deltaTime);
        
        if (Input.GetKey("d"))
        {
            //Slide right, trying to do more of a teleport instead to the right lane
            rb.AddForce(sidepush * Time.deltaTime,0,0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            //Slide right, trying to do more of a teleport instead to the right lane
            rb.AddForce(-(sidepush) * Time.deltaTime,0,0, ForceMode.VelocityChange);
            
        }

        if (rb.position.y < -1f) //If fall off the map, restart
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
