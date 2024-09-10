using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CarController : MonoBehaviour
{
    [SerializeField] private float horsePower;
    [SerializeField] private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody carRb;
    [SerializeField] private GameObject centerOfMass;

    private void Start()
    {
        carRb = GetComponent<Rigidbody>();
        carRb.centerOfMass = centerOfMass.transform.localPosition;
    }

    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        // move the car forward based on vertical input
        // changed speed to horsePower
        // transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        carRb.AddRelativeForce(Vector3.forward * Time.deltaTime * horsePower * forwardInput);

        // rotate the car based on horizontal input
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);     
    }
}
