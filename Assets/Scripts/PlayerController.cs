using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 50.0f; //speed of hero
    public Rigidbody head;
    public LayerMask layerMask; //what layers the ray should hit

    private CharacterController characterController;
    private Vector3 currentLookTarget = Vector3.zero; //where you want the marine to look

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //move character and not allowing character to go through objects
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.SimpleMove(moveDirection * moveSpeed);
    }

    void FixedUpdate()
    {
        //moves head when SpaceMarine moves
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (moveDirection == Vector3.zero)
        {
            // TODO
        }
        else
        {
            head.AddForce(transform.right * 150, ForceMode.Acceleration);
        }

        RaycastHit hit; //creates empty hit
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //cast ray from main camera to mouse position
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green); //draw ray in scene view when playing

        //casts the ray .. pass in the ray .. length of ray 1000m .. what you are trying to hit .. not to activate triggers
        if (Physics.Raycast(ray, out hit, 1000, layerMask, QueryTriggerInteraction.Ignore))
        {
            //where hero should look
            if (hit.point != currentLookTarget)
            {
                currentLookTarget = hit.point;
            }
        }
        
        // target position
        Vector3 targetPosition = new Vector3(hit.point.x,
        transform.position.y, hit.point.z);
        // current quaternion
        Quaternion rotation = Quaternion.LookRotation(targetPosition -
        transform.position);
        // actual turn
        transform.rotation = Quaternion.Lerp(transform.rotation,
        rotation, Time.deltaTime * 10.0f);
    }
}
