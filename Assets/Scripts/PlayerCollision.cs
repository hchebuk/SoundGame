using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    private int count;
    public TextMeshProUGUI countText;

    void Start()
    {
        count = 0;
        SetCountText();
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle") 
        {
            //Add function when player hits obstacle
            
            FindObjectOfType<GameManager>().EndGame(); //Looks for gamemanager object and calls that
        }
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
        countText.text = "Score: " + count.ToString();
    }
}
