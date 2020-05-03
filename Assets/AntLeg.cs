using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntLeg : MonoBehaviour
{        
    public GameObject shoulder;
    public GameObject femur;
    public GameObject tibia;
    public GameObject tarsus;
    public GameObject claw;

    private List<GameObject> bodyParts;
    private List<Vector3> defaultBodyPartsOffset;
    private Vector3 lastMainPosition; 
    private Vector3 mainPositionDelta;

    void Start()
    {
        bodyParts = new List<GameObject>();
        bodyParts.Add(shoulder);
        bodyParts.Add(femur);
        bodyParts.Add(tibia);
        bodyParts.Add(tarsus);       

        lastMainPosition = claw.transform.position; 
    }

    void FixedUpdate() {
        
        Vector3 currentMainPosition = claw.transform.position;
        mainPositionDelta = currentMainPosition - lastMainPosition;            

        foreach(var bodyPart in bodyParts) {
            bodyPart.transform.position += mainPositionDelta;                         
        }
        
        lastMainPosition = currentMainPosition;
    }
}
