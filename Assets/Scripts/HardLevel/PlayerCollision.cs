using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    private int count;
    //public int bounceWCount;
    //private int bounceECount;
    //public float timer = 0.0f;
    //private float waitTime = 0.1f;
    public TextMeshProUGUI countText;
    public Rigidbody rb;

    

    void Start()
    {
        count = 0;
        SetCountText();
        //bounceWCount = 0;
       // bounceECount = 0;
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        //timer += Time.deltaTime;

        if (collisionInfo.collider.tag == "Obstacle") 
        {
            //Add function when player hits obstacle
            
            FindObjectOfType<GameManager>().EndGame(); //Looks for gamemanager object and calls that
        }

        /*
        // When hitting west wall
        if (collisionInfo.collider.tag == "SideWallWest")
        {
            if (timer < waitTime)
            {
                bounceWCount += 1;
            }
            

            if (bounceWCount >= 3 && timer > waitTime)
            {
                bounceWCount = 0;
                timer = 0;
                rb.AddForce(20, 0, 0, ForceMode.VelocityChange);
            }

            // move player right
            rb.AddForce(13, 0, 0, ForceMode.VelocityChange);

            // move player forward

            rb.AddForce(0, 0, 6);
        }

        // hitting east wall
        if (collisionInfo.collider.tag == "SideWallEast")
        {
            // move player left
            rb.AddForce(-13 , 0, 0, ForceMode.VelocityChange);

            // move player forward

            rb.AddForce(0, 0, 5);
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "" + count.ToString();
    }
}
