using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class CarController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float horsePower;
    [SerializeField] private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody carRb;
    [SerializeField] private GameObject centerOfMass;
    [SerializeField] private TextMeshProUGUI speedMeterText; 

    private void Start()
    {
        carRb = GetComponent<Rigidbody>();
        carRb.centerOfMass = centerOfMass.transform.localPosition;
    }

    void FixedUpdate()
    {
        speed = Mathf.Round(carRb.velocity.magnitude * 3.6f); //3.6 for kph
        speedMeterText.SetText("Speed: " + speed + "Km/h");


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
