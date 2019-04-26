using UnityEngine;

public class LiftError : MonoBehaviour
{
    private AudioSource _as;
    private float nextActionTime;
    public float period = 5f;

    void Awake()
    {
        _as = GetComponent<AudioSource>();
    }



    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime = Time.time + period;
            // execute block of code here
            _as.Play();
        }
    }
}
