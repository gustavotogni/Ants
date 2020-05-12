using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    public GameObject main;
    public List<GameObject> bodyParts;
    private List<Vector3> defaultBodyPartsOffset;
    private Vector3 lastMainPosition; 
    private Vector3 mainPositionDelta;

    void Start()
    {
        main = bodyParts[0];
        lastMainPosition = main.transform.position;
        bodyParts.RemoveAt(0);
        
        foreach(var bodyPart in bodyParts) {

            //Vector3.Distance(bodyPart.transform.position);
            //defaultBodyPartsOffset.Add(
        }              
    }

    void Update()
    {
        
    }

    void FixedUpdate() {
        
        Vector3 currentMainPosition = main.transform.position;
        mainPositionDelta = currentMainPosition - lastMainPosition;            

        foreach(var bodyPart in bodyParts) {
            bodyPart.transform.position += mainPositionDelta;
        }
        
        lastMainPosition = currentMainPosition;
    }
}
