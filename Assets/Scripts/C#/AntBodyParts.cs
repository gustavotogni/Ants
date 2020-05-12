using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntBodyParts {
    
    private List<GameObject> _antBodyParts;
    private List<Vector3> _lastBodyPartPositions; 
    private List<float> _maxDistancesToPreviousPart;

    private GameObject _joint;
    private Vector3 _lastJointPosition;

    public AntBodyParts(GameObject joint, List<GameObject> antBodyParts) {
        
        _antBodyParts = antBodyParts;        
        _lastBodyPartPositions = new List<Vector3>();
        _maxDistancesToPreviousPart = new List<float>();
        
        _joint = joint;
        _lastJointPosition = _joint.transform.position;
        
        foreach(var bodyPart in _antBodyParts) {          
            _maxDistancesToPreviousPart.Add(Vector3.Distance(bodyPart.transform.position, _joint.transform.position));
            _lastBodyPartPositions.Add(bodyPart.transform.position);
        }  
    }

    public void MoveBodyPartsNew () {

        GameObject refBodyParty = _joint;
        for(int i = 0; i < _antBodyParts.Count; i++) {
            
            var curBodyPart = _antBodyParts[i];   
                                
            Vector3 curBodyPartPos = curBodyPart.transform.position;
            Vector3 refBodyPartPos = refBodyParty.transform.position;                

            float curDistanceToReferencePart = Vector3.Distance(curBodyPartPos, refBodyPartPos);
            float maxDistanceToReferencePart = _maxDistancesToPreviousPart[i];

            if (curDistanceToReferencePart > maxDistanceToReferencePart) {
                
                Debug.Log(
                    string.Format("Distance of {0} between {1} and {2} exceeds the maximum default value of {3}", 
                    curDistanceToReferencePart, curBodyPart.name, refBodyParty.name, maxDistanceToReferencePart)
                );
                
                this.MoveBodyPart(curBodyPart, refBodyPartPos - _lastJointPosition);
            }
            
            Vector3 direction = curBodyPartPos - refBodyPartPos;
            Quaternion toRotation = Quaternion.FromToRotation(curBodyPart.transform.right, direction);

            if (toRotation.x > 0f || toRotation.y > 0f || toRotation.z > 0f) {

                Debug.Log(
                    string.Format("Rotated {0} towards {1}. To Rotation: {2}", 
                    curBodyPart.name, refBodyParty.name, toRotation.eulerAngles)
                ); 

                this.RotateBodyPart(refBodyParty.transform, curBodyPart);               
            }
            
            _lastBodyPartPositions[i] = curBodyPart.transform.position;
        }    

        _lastJointPosition = _joint.transform.position;
    }

    private void MoveBodyPart(GameObject bodyPartToMove, Vector3 referencePosition) {
        bodyPartToMove.transform.position = bodyPartToMove.transform.position + referencePosition;
    }

    private void RotateBodyPart(Transform referenceTransform, GameObject bodyPartToRotate) {
        bodyPartToRotate.transform.LookAt(referenceTransform, Vector3.up);
        Debug.Log(bodyPartToRotate.transform.rotation);

        var offset = 90f;
        if (bodyPartToRotate.transform.rotation.x <= -0.7f) {
            //offset = 0;
        }

        bodyPartToRotate.transform.Rotate(Vector3.left, offset);             
    }
}