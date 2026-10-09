using System.Collections;
using UnityEngine;
namespace SumoBall
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody playerRb;
        private GameObject focalPoint;

        public float speed = 5.0f;
        public bool hasPowerup;
        public GameObject powerupIndicator;

        private float powerupStrength = 15.0f;
        private Coroutine powerupRoutine;

        void Start()
        {
            playerRb = GetComponent<Rigidbody>();
            focalPoint = GameObject.Find("Focal Point");
        }

        void Update()
        {
            float forwardInput = Input.GetAxis("Vertical");
            playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

            // Keep the indicator under the player
            powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Powerup"))
            {
                hasPowerup = true;
                Destroy(other.gameObject);
                powerupIndicator.gameObject.SetActive(true);

                // Restart the timer if a second powerup is grabbed while one is active
                if (powerupRoutine != null)
                {
                    StopCoroutine(powerupRoutine);
                }
                powerupRoutine = StartCoroutine(PowerupCountdownRoutine());
            }
        }

        IEnumerator PowerupCountdownRoutine()
        {
            yield return new WaitForSeconds(7);
            hasPowerup = false;
            powerupIndicator.gameObject.SetActive(false);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
            {
                Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;

                Debug.Log("Player collided with " + collision.gameObject + " with powerup set to " + hasPowerup);
                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
        }
    }
}
