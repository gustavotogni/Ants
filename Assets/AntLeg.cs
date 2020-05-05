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
    public Text guiText;

    private ABP_References abpRefs;

    void Start() {
        abpRefs = new ABP_References(new List<GameObject>{claw, tarsus, tibia, femur, shoulder});
    }

    void FixedUpdate() {

        guiText.text = Time.deltaTime.ToString();
        abpRefs.DoLogic();
    }
}
