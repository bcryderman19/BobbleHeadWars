using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaWall : MonoBehaviour
{
    private Animator arenaAnimator;
    // Start is called before the first frame update
    void Start()
    {
        GameObject arena = transform.parent.gameObject; //gets parent GameObject by accessing the parent property
        arenaAnimator = arena.GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        arenaAnimator.SetBool("IsLowered", true);
    }

    void OnTriggerExit(Collider other)
    {
        arenaAnimator.SetBool("IsLowered", false);
    }
}
