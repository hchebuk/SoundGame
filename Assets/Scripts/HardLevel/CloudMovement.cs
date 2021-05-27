using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{

    
    
    private float x;
    private float y;
    private float z;
    // Update is called once per frame

    void Start()
    {
        
        x = UnityEngine.Random.Range(0, 10);
        y = UnityEngine.Random.Range(0, 10);
        z = UnityEngine.Random.Range(0, 10);
    }

    void Update()

    {
        
        //transform.Translate(new Vector3(x, 1, z) * Time.deltaTime);

        transform.Rotate(new Vector3(0, 20, 0) * Time.deltaTime);//Rotating pickup
    }
}
