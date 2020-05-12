using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntTarsus : MonoBehaviour
{
    private Quaternion previousRotation;
    private Vector3 previousPosition;

    public GameObject claw;

    void FixedUpdate()
    {
        Debug.Log("pos + rot: " + transform.rotation + ", " + transform.position);

        Vector3 currentPosition = transform.position;
        Quaternion currentRotation = transform.rotation;

        Vector3 positionDelta = currentPosition - previousPosition;
        //Quaternion rotationDelta = currentRotation - previousRotation;

         //transform.LookAt(claw.transform, Vector3.up);
           //   transform.Rotate(Vector3.right, 90);

        //currentRotation.x += positionDelta.x;
        //currentRotation.z += positionDelta.y;
        //currentRotation.z += positionDelta.z;
        //currentRotation.w += currentRotation.w;
        //transform.rotation = currentRotation;

        //previousPosition = currentPosition;
        
    }
}
