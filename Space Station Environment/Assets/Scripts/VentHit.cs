using UnityEngine;

public class VentHit : MonoBehaviour
{
    private AudioSource impactSound;

    void Awake()
    {
        impactSound = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 2)
        {
           impactSound.Play();
        }
    }
}
