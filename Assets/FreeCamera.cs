using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCamera : MonoBehaviour
{
    private float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0,-speed * Time.deltaTime, 0));
        }
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0,speed * Time.deltaTime, 0));
        }
         if(Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(speed * Time.deltaTime * 10.0f, 0, 0));
        }
         if(Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(speed * Time.deltaTime * -10.0f, 0, 0));
        }
    }
}
