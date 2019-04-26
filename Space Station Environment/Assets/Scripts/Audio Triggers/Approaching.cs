using UnityEngine;

public class Approaching : MonoBehaviour
{
    private AudioSource _AudioSource;
    private GameObject player;
    private Vector3 dest;
    public AudioClip[] approachingSounds;    
    public float speed = 0.5f;

    void Awake()
    {
        _AudioSource = transform.GetChild(0).GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        dest = player.transform.position;        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {            
            PlayApproachingCreatureAudio();
            Destroy(gameObject, 13f);
        }
    }

    public void PlayApproachingCreatureAudio()
    {
        ApproachingClip();
        if (!_AudioSource.isPlaying)
        {
            _AudioSource.PlayOneShot(_AudioSource.clip);
            MoveToPlayer();
        }
    }

    void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, dest, speed);
    }

    private void ApproachingClip()
    {
        _AudioSource.clip = approachingSounds[Random.Range(0, approachingSounds.Length)];
    }
}
