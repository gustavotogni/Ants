using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AntLeg : MonoBehaviour
{        
    public GameObject shoulder;
    public GameObject femur;
    public GameObject tibia;
    public GameObject tarsus;
    public GameObject claw;

    public GameObject femurJoint;
    public GameObject tibiaJoint;
    public GameObject tarsusJoint;

    public Text guiText;

    private AntBodyParts abpRefs;

    

    void Start() {
        abpRefs = new AntBodyParts(gameObject, new List<GameObject>{claw, tarsus, tarsusJoint, tibia, tibiaJoint, femur, femurJoint, shoulder});
    }

    void FixedUpdate() {

        guiText.text = Time.deltaTime.ToString();
        abpRefs.DoLogic();
        
        if (Input.GetKeyDown(KeyCode.B)) {
            abpRefs.DoLogicTwo();

        }
    }
}
