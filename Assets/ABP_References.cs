using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABP_References {
    
    private List<GameObject> _antBodyParts;
    private List<Vector3> _lastBodyPartPositions; 
    private List<float> _maxDistancesToPreviousPart;

    public ABP_References(List<GameObject> antBodyParts) {
        
        _antBodyParts = antBodyParts;        
        _lastBodyPartPositions = new List<Vector3>();
        _maxDistancesToPreviousPart = new List<float>();
        
        GameObject previousBodyPart = null;
        foreach(var bodyPart in _antBodyParts) {
                        
            if (previousBodyPart != null) {                
                _maxDistancesToPreviousPart.Add(Vector3.Distance(bodyPart.transform.position, previousBodyPart.transform.position));
            }

            _lastBodyPartPositions.Add(bodyPart.transform.position);
            previousBodyPart = bodyPart;            
        }  
    }

    public void DoLogic() {
                
        GameObject previousBodyPart = null;
        for(int i = 0; i < _antBodyParts.Count; i++) {
            
            var bodyPart = _antBodyParts[i];            
            if (previousBodyPart != null) {            

                bodyPart.transform.LookAt(previousBodyPart.transform, Vector3.up);
                bodyPart.transform.Rotate(Vector3.right, 90);                              
                
                Vector3 currBodyPartPos = bodyPart.transform.position;
                Vector3 prevBodyPartPos = previousBodyPart.transform.position;

                float curDistanceToPreviousPart = Vector3.Distance(currBodyPartPos, prevBodyPartPos);
                float maxDistanceToPreviousPart = _maxDistancesToPreviousPart[i - 1];

                if (curDistanceToPreviousPart > maxDistanceToPreviousPart) {
                    Debug.Log(
                        string.Format("Distance of {0} between {1} and {2} exceeds the maximum default value of {3}", 
                        curDistanceToPreviousPart, bodyPart.name, previousBodyPart.name, maxDistanceToPreviousPart)
                    );

                    //var prevBodyPartPosDelta = prevBodyPartPos - _lastBodyPartPositions[i - 1];
                    //bodyPart.transform.position = bodyPart.transform.position + prevBodyPartPosDelta;
                    //bodyPart.transform.position = new Vector3(0f, 0f, 0f);

                    bodyPart.transform.position = Vector3.MoveTowards(currBodyPartPos, prevBodyPartPos, 2.0f * Time.deltaTime);
                }
            }
            
            _lastBodyPartPositions[i] = bodyPart.transform.position;
            previousBodyPart = bodyPart;            
        }    
    }
}