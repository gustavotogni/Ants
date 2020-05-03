using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntClaw : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private List<Vector3> _clawDestinations;
    private bool _adheredToSomething = false;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) {
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(new Vector3(0.0f, 10.0f, 0.0f), ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.C)) {

            _rigidbody.isKinematic = false;
            _rigidbody.useGravity = false;

            _clawDestinations = new List<Vector3>();
            _clawDestinations.Add(transform.position + new Vector3(0.0f,  2.0f, 0.0f));
            _clawDestinations.Add(transform.position + new Vector3(1.0f,  2.0f, 0.0f));
            _clawDestinations.Add(transform.position + new Vector3(1.0f, -1.0f, 0.0f));
        }

        
        if (_clawDestinations != null) {
        	MoveClawB(); 
        }
    }

    
    void MoveClawB() {
        
        if (_clawDestinations.Count > 0) {
        	Vector3 currentDestination = _clawDestinations[0];
        	if (Vector3.Distance(transform.position, currentDestination) > 1.0f) {            
                transform.position = Vector3.MoveTowards(transform.position, currentDestination, 2.0f * Time.deltaTime);
            } else {
            	_clawDestinations.RemoveAt(0);
            }
        }
    }
    
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
