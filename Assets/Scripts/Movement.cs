using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float thrust = 1000f;
    [SerializeField] float rotationalThrust = 100f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space)) {
            rb.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
        }        
    }

    void ProcessRotation()
    {
        if (!(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))) { // checks to make sure both buttons aren't being pressed together
            if (Input.GetKey(KeyCode.A))
            {
                applyRotation(rotationalThrust);
            }
            if (Input.GetKey(KeyCode.D)) {
                applyRotation(-rotationalThrust);
            }
        }
    }

    private void applyRotation(float rotation)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * Time.deltaTime * rotation);
        rb.freezeRotation = false; // unfreezing rotation so physics system can  take over
    }
}
