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
    private float defaultTrunkToShoulderAngle;

    void Start()
    {
        bodyParts = new List<GameObject>();
        bodyParts.Add(this.gameObject);
        bodyParts.Add(shoulder1);
        shoulder2 = shoulder1;
        lastMainPosition = shoulder1.transform.position;

        defaultTrunkToShoulderAngle = Vector3.SignedAngle(transform.position, shoulder1.transform.position, new Vector3(0.0f, 0.0f, 1.0f));
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

            foreach(var bodyPart in bodyParts) {
                    //bodyPart.transform.position += mainPositionDelta;
            
            }
            
            lastMainPosition = currentMainPosition;

            float currentTrunkToShoulderAngle = Vector3.SignedAngle(transform.position, shoulder1.transform.position, new Vector3(0.0f, 0.0f, 1.0f));
            float angleDelta = defaultTrunkToShoulderAngle - currentTrunkToShoulderAngle;
            if (angleDelta < 0) {
                shoulder1.transform.Rotate(0.0f, 0.0f, 1.0f);
            } else if (angleDelta > 0) {
                shoulder1.transform.Rotate(0.0f, 0.0f, -1.0f);
            }

            defaultTrunkToShoulderAngle = currentTrunkToShoulderAngle;

        }
    }
}
