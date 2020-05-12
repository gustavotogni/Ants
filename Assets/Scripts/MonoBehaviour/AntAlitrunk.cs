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

        defaultTrunkToShoulderAngle = Vector3.Angle(transform.position, shoulder1.transform.position) * Mathf.Rad2Deg;
        Debug.Log("Default:"  + defaultTrunkToShoulderAngle);
    }

    void FixedUpdate() {

        //float maxDistanceBetweenShoulders = 1.2f;
        //float distanceBetweenShoulders = Vector3.Distance(shoulder1.transform.position, shoulder2.transform.position);
        //if (distanceBetweenShoulders > maxDistanceBetweenShoulders) {
        //    Debug.Log("dead ant");
            //Destroy(this.gameObject);
        //} else {
            
            //Vector3 currentMainPosition = shoulder1.transform.position;
            //mainPositionDelta = currentMainPosition - lastMainPosition;            
            
            //lastMainPosition = currentMainPosition;

            float currentTrunkToShoulderAngle = Vector3.Angle(transform.position, shoulder1.transform.position) * Mathf.Rad2Deg;
            float angleDelta = Mathf.DeltaAngle(defaultTrunkToShoulderAngle, currentTrunkToShoulderAngle) * Mathf.Rad2Deg;

            Debug.Log("AD:" + angleDelta);
            
            //shoulder1.transform.LookAt(transform.position);
            if (angleDelta < 0) {
                
            } else if (angleDelta > 0) {
               // shoulder1.transform.Rotate(0.0f, 0.0f, (angleDelta + 1.04f) *  1);              
            }

            //defaultTrunkToShoulderAngle = currentTrunkToShoulderAngle;

            if (shoulder1.transform.rotation.z > 1.04f) {       
                Debug.Log("Move body");
                //transform.position = Vector3.MoveTowards(transform.position, shoulder1.transform.position, 2.0f * Time.deltaTime);
            } else {
                
            }
        //}
    }
}
