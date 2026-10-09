using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DrivingGame
{
    public class PlayerController : MonoBehaviour
    {
        // Variables
        private float speed = 20.0f;
        private float turnSpeed = 45.0f;
        private float horizontalInput;
        private float forwardInput;

        // Update is called once per frame
        void Update()
        {
            // Read player input
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");

            // Moves the car forward based on vertical input
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

            // Rotates the car based on horizontal input
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        }
    }
}
