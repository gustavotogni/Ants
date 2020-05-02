using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntClaw : MonoBehaviour
{
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        clawDestinationB = transform.position;
    }

    Vector3 clawDestinationA;
    Vector3 clawDestinationB;
    Vector3 clawDestinationC;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) {
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(new Vector3(0.0f, 10.0f, 0.0f), ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.X)) {
            _rigidbody.isKinematic = false;
            clawDestinationA = transform.position + new Vector3(1.0f, 5.0f, 0.0f);
            MoveClawA(); 
            
        }

        if (Input.GetKeyDown(KeyCode.C)) {
            _rigidbody.isKinematic = false;
            _rigidbody.useGravity = false;

            clawDestinationB = transform.position + new Vector3(0.0f,  2.0f, 0.0f);
            clawDestinationC = transform.position + new Vector3(0.0f, -1.0f, 0.0f);
            moveToB = true;
        }

        
        MoveClawB(); 
    }

    private bool moveToB = false;
    private bool moveToC = false;

    void MoveClawB() {
        
        if (moveToB) {
            if (Vector3.Distance(transform.position, clawDestinationB) > 1.0f) {            
                transform.position = Vector3.MoveTowards(transform.position, clawDestinationB, 2.0f * Time.deltaTime);
            } else {
                clawDestinationB = transform.position;
                moveToB = false;
                moveToC = true;
            }
        } else if (moveToC) {
            if (Vector3.Distance(transform.position, clawDestinationC) > 1.0f) {            
                transform.position = Vector3.MoveTowards(transform.position, clawDestinationC, 2.0f * Time.deltaTime);
            } else {
                clawDestinationC = transform.position;
                moveToC = false;
            }
        }
    }

    void MoveClawA() {
        
        //_rigidbody.AddForce(new Vector3(1.0f, 5.0f, 0.0f), ForceMode.Impulse);
    }

    private bool _adheredToSomething = false;
    
    void OnCollisionEnter(Collision other) {
        
        if(other.collider.tag == "floor" && !_adheredToSomething) {            
            Debug.Log("floor");
            
            //_rigidbody.isKinematic = true;
            _adheredToSomething = true;

            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero; 

            //Vector3 newPosition = transform.position + new Vector3(0.0f, 0.05f, 0.0f);
            //transform.position = newPosition;
        }
    }

    void OnCollisionExit(Collision other) {
        Debug.Log("exit floor");
        if(other.collider.tag == "floor") {
            //_rigidbody.isKinematic = false;
            _adheredToSomething = false;
            
            
        }
    }
}
