using UnityEngine;

public class Regular : MonoBehaviour
{
    private AudioSource _AudioSource;

    public AudioClip[] regularSounds;

    void Awake()
    {
        _AudioSource = transform.GetChild(0).GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayRegularCreatureAudio();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    public void PlayRegularCreatureAudio()
    {
        RegularClip();
        if (!_AudioSource.isPlaying)
        {
            _AudioSource.PlayOneShot(_AudioSource.clip);
        }
    }

    private void RegularClip()
    {
        _AudioSource.clip = regularSounds[Random.Range(0, regularSounds.Length)];
    }
}
