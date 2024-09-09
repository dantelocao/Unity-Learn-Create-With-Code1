using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundaries : MonoBehaviour
{
    public float topBound;
    public float lowerBound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z > lowerBound)
        {
            Debug.Log("Game over!");
            Destroy(gameObject);
        }
        
    }
}
