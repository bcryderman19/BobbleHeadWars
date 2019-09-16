using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Alien : MonoBehaviour
{
    public Transform target; //where alien should go

    private NavMeshAgent agent;
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
            agent.destination = target.position;
        }
    }
}
