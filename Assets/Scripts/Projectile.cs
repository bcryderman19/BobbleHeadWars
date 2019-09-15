using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameInvisible() //destroy bullet when it is off screen
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision) //destroys bullet during event
    {
        Destroy(gameObject);
    }
}
