using UnityEngine;

public class Pressurize : MonoBehaviour
{
    private AudioSource _AudioSource;
    public AudioClip[] steamSounds;
    public ParticleSystem[] steamParticles;

    // Start is called before the first frame update
    void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetSteamClip();

            if (!_AudioSource.isPlaying)
            {
                _AudioSource.PlayOneShot(_AudioSource.clip);
                steamParticles[0].Play();
                steamParticles[1].Play();
                steamParticles[2].Play();
                steamParticles[3].Play();
            }
        }
    }

    private void GetSteamClip()
    {
        _AudioSource.clip = steamSounds[Random.Range(0, steamSounds.Length)];
    }
}
