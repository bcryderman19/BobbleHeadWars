using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject followTarget; //what camera will follow 
    public float moveSpeed; // speed it will follow at
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (followTarget != null) //checking for target to follow
        {
            transform.position = Vector3.Lerp(transform.position,
            followTarget.transform.position, Time.deltaTime * moveSpeed);
        }
    }
}
