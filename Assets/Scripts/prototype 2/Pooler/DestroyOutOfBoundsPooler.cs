using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsPooler : MonoBehaviour
{
    private float topBound = -50;
    private float lowerBound = 40;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < topBound && gameObject.CompareTag("Projectile"))
        {
            // Instead of destroying the projectile when it leaves the screen
            //Destroy(gameObject);

            // Just deactivate it
            gameObject.SetActive(false);

        }
        else if (transform.position.z > lowerBound && gameObject.CompareTag("Dog"))
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }

    }
}
