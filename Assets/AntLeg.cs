using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntLeg : MonoBehaviour
{    
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
        bodyParts.Add(femur);
        bodyParts.Add(tibia);
        bodyParts.Add(tarsus);
        //bodyParts.Add(claw);

        lastMainPosition = claw.transform.position;
        
        
        foreach(var bodyPart in bodyParts) {

            //Vector3.Distance(bodyPart.transform.position);
            //defaultBodyPartsOffset.Add(
        }              
    }

    void Update()
    {
         //claw.transform.Translate(new Vector3(0.1f * Time.deltaTime, 0.0f, 0.0f));
    }

    void FixedUpdate() {
        
        Vector3 currentMainPosition = claw.transform.position;
        mainPositionDelta = currentMainPosition - lastMainPosition;            

        int i = 0;
        foreach(var bodyPart in bodyParts) {
            if (i <= 0) {
                bodyPart.transform.position += mainPositionDelta;
                i++;
            } else {
                break;
            }            
        }
        
        lastMainPosition = currentMainPosition;
    }
}
