using UnityEngine;

public class ComputerSparks : MonoBehaviour
{
    private AudioSource _AudioSource;
    public AudioClip[] sparkSounds;
    private ParticleSystem sparksParticle;
    readonly System.Random rnd = new System.Random();

    void Awake()
    {
        _AudioSource = GetComponent<AudioSource>();
        sparksParticle = gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        int Chance = rnd.Next(1, 100);

        GetSparkClip();

        if (!_AudioSource.isPlaying && Chance == 1)
        {
            _AudioSource.PlayOneShot(_AudioSource.clip);
            sparksParticle.Play();
        }
    }

    private void GetSparkClip()
    {
        _AudioSource.clip = sparkSounds[Random.Range(0, sparkSounds.Length)];
    }
}
