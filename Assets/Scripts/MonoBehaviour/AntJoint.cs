using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntJoint : MonoBehaviour
{
    public GameObject partFrom;
    public GameObject partTo;

    private Rigidbody _rigidbody;
    private List<Vector3> _clawDestinations;
    private List<Vector3> defaultBodyPartsOffset;
    private Vector3 lastMainPosition; 
    private Vector3 mainPositionDelta;
    private AntBodyParts abpRefs;

    void Start() {
        
        _rigidbody = GetComponent<Rigidbody>();      
        abpRefs = new AntBodyParts(gameObject, new List<GameObject>{partFrom, partTo}); 
    }

    void FixedUpdate() {
        
        Vector3 currentMainPosition = transform.position;
        mainPositionDelta = currentMainPosition - lastMainPosition;
        lastMainPosition = currentMainPosition;

        abpRefs.MoveBodyPartsNew();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)) {

            //_rigidbody.isKinematic = false;
            //_rigidbody.useGravity = false;

            _clawDestinations = new List<Vector3>();
            _clawDestinations.Add(transform.position + new Vector3(0.0f,  2.0f, 0.0f));
            _clawDestinations.Add(transform.position + new Vector3(1.0f,  2.0f, 0.0f));
            _clawDestinations.Add(transform.position + new Vector3(1.0f, -1.0f, 0.0f));
        }

        if (Input.GetKeyDown(KeyCode.T)) {
            abpRefs.MoveBodyPartsNew();
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
}
