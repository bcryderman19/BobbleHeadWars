﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Alien : MonoBehaviour
{
    public Transform target; //where alien should go
    public float navigationUpdate; //m/s for when alien updates its path

    private NavMeshAgent agent;
    private float navigationTime = 0; // tracks how much time has passed
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); //reference to navMesh
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            navigationTime += Time.deltaTime; //how much time has passed then updates 
            if (navigationTime > navigationUpdate)
            {
                agent.destination = target.position;
                navigationTime = 0;
            }
        }
    }
    private void OnTriggerEnter(Collider other) //collision event into trigger because alien rigidbody is kinematic
    {
        Destroy(gameObject);
    }
}
