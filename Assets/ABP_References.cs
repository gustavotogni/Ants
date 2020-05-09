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

    public void DoLogicTwo() {
        
                var lookRotation = Vector3.SignedAngle(_antBodyParts[1].transform.position, _antBodyParts[0].transform.position, Vector3.right);
                //Debug.Log(string.Format("Look rotation for {0} is {1}", _antBodyParts[1], lookRotation));
                //if (lookRotation > 0) {
                    //_antBodyParts[1].transform.RotateAround(_antBodyParts[1].transform.position, Vector3.right, lookRotation);                              
                    //_antBodyParts[1].transform.LookAt(_antBodyParts[0].transform, Vector3.up);
                    //_antBodyParts[1].transform.LookAt(new Vector3(1.0f, 0.0f, 0.0f), lookRotation, Space.Self);

                    Vector3 direction = _antBodyParts[1].transform.position - _antBodyParts[0].transform.position;
                    Debug.Log(direction);
                    Quaternion toRotation = Quaternion.FromToRotation(_antBodyParts[1].transform.up, direction);
                    Debug.Log(toRotation);
                    _antBodyParts[1].transform.rotation = Quaternion.Lerp(_antBodyParts[1].transform.rotation, toRotation, 2.0f * Time.time);
                //}

        
        
    }

    public void DoLogic() {
                
        GameObject previousBodyPart = null;
        for(int i = 0; i < _antBodyParts.Count; i++) {
            
            var bodyPart = _antBodyParts[i];            
            if (previousBodyPart != null) {            
                                
                Vector3 currBodyPartPos = bodyPart.transform.position;
                Vector3 prevBodyPartPos = previousBodyPart.transform.position;

                Vector3 direction = _antBodyParts[i].transform.position - _antBodyParts[i - 1].transform.position;
                Quaternion toRotation = Quaternion.FromToRotation(_antBodyParts[i].transform.up, direction);            

                if (
                    toRotation.x > 0f ||
                    toRotation.y > 0f ||
                    toRotation.z > 0f 
                ) {
                    _antBodyParts[i].transform.rotation = toRotation;//Quaternion.Lerp(_antBodyParts[i].transform.rotation, toRotation, 20.0f * Time.time);    

                    Debug.Log("roit" + _antBodyParts[i].transform.rotation.eulerAngles);
                     Debug.Log("norm" + toRotation.eulerAngles);

                                     Debug.Log(
                        string.Format("Rotated {0} towards {1}. To Rotation: {2}", 
                        bodyPart.name, previousBodyPart.name, toRotation.eulerAngles)
                    );  
                }


                
                
                
          

                float curDistanceToPreviousPart = Vector3.Distance(currBodyPartPos, prevBodyPartPos);
                float maxDistanceToPreviousPart = _maxDistancesToPreviousPart[i - 1];

                if (curDistanceToPreviousPart > maxDistanceToPreviousPart) {
                    Debug.Log(
                        string.Format("Distance of {0} between {1} and {2} exceeds the maximum default value of {3}", 
                        curDistanceToPreviousPart, bodyPart.name, previousBodyPart.name, maxDistanceToPreviousPart)
                    );

                    var prevBodyPartPosDelta = prevBodyPartPos - _lastBodyPartPositions[i - 1];
                    //bodyPart.transform.position = Vector3.MoveTowards(currBodyPartPos, prevBodyPartPos, 2.0f * Time.deltaTime);
                }
            }
            
            _lastBodyPartPositions[i] = bodyPart.transform.position;
            previousBodyPart = bodyPart;    

            if (i > 2) {
                break;
            }
        }    
    }
}