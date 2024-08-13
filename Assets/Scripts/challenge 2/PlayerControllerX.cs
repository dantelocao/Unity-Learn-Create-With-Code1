using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private float coolStatus;
    private const float coolDownTime = 0.5f; // in seconds

    // Update is called once per frame
    void Update()
    {
        // if cooldown is inacted
        if (coolStatus > 0)
        {
            // Subtract the time passed between the frames from the cooldown
            coolStatus -= Time.deltaTime;
        }

        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // If there is no active cooldown
            if (coolStatus <= 0)
            {
                // Assign cooldown limit to tracking variable, and then spawn the dog
                coolStatus = coolDownTime;
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            }
        }
    }
}