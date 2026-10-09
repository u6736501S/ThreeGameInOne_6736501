using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPropellerX : MonoBehaviour
{
    public float rotationSpeed = 1000f;

    // Update is called once per frame
    void Update()
    {
        // spin the propeller around the Z axis
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
