using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class CarController : MonoBehaviour
{
    private float speed;
    [SerializeField] private float horsePower;
    [SerializeField] private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody carRb;
    [SerializeField] private GameObject centerOfMass;
    [SerializeField] private TextMeshProUGUI speedMeterText;
    [SerializeField] private TextMeshProUGUI rpmText;
    private float rpm;

    [SerializeField] private List<WheelCollider> allWheels;
    private int wheelsOnGround;

    private void Start()
    {
        carRb = GetComponent<Rigidbody>();
        carRb.centerOfMass = centerOfMass.transform.localPosition;

    }

    void FixedUpdate()
    {
        speed = Mathf.Round(carRb.velocity.magnitude * 3.6f); //3.6 for kph
        speedMeterText.SetText("Speed: " + speed + "Km/h");

        rpm = Mathf.Round((speed % 30) * 40);
        rpmText.SetText("Rpm: " + rpm);

        if (isOnGround())
        {
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");

            if (speed <= 60)
            {
                carRb.AddRelativeForce(Vector3.forward * horsePower * Time.deltaTime * forwardInput);
            }

            if (speed > 0)
            {
                carRb.AddTorque(Vector3.up * turnSpeed * horizontalInput * Time.deltaTime);
            }

        }

    }

    bool isOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        if (wheelsOnGround == 0)
        {
            return false;

        } else
        {
            return true;
        }

    }
}