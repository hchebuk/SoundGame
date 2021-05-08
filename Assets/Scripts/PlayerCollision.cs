using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle") 
        {
            //Add function when player hits obstacle
            
            //FindObjectOfType<GameManager>().EndGame(); //Looks for gamemanager object and calls that
        }
    }
}
