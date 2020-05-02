using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntAlitrunk : MonoBehaviour
{
    public GameObject shoulder1;
    public GameObject shoulder2;
    
    private List<GameObject> bodyParts;

    private List<Vector3> defaultBodyPartsOffset;
    private Vector3 lastMainPosition; 
    private Vector3 mainPositionDelta;

    void Start()
    {
        bodyParts = new List<GameObject>();
        bodyParts.Add(this.gameObject);
        bodyParts.Add(shoulder2);
        
        lastMainPosition = shoulder1.transform.position;
    }

    void FixedUpdate() {

        float maxDistanceBetweenShoulders = 1.2f;
        float distanceBetweenShoulders = Vector3.Distance(shoulder1.transform.position, shoulder2.transform.position);
        if (distanceBetweenShoulders > maxDistanceBetweenShoulders) {
            Debug.Log("dead ant");
            //Destroy(this.gameObject);
        } else {
            
            Vector3 currentMainPosition = shoulder1.transform.position;
            mainPositionDelta = currentMainPosition - lastMainPosition;            

            int i = 0;
            foreach(var bodyPart in bodyParts) {
                if (i <= 0) {
                    //bodyPart.transform.position += mainPositionDelta;
                    i++;
                } else {
                    break;
                }            
            }
            
            lastMainPosition = currentMainPosition;
        }
    }
}
