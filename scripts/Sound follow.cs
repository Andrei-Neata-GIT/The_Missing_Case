using UnityEngine;

public class FollowPlayerSound : MonoBehaviour
{
    public AudioSource audioSource;

    [Header("Settings")]
    public bool playOnlyOnce = true;

    private Transform player;
    private bool hasPlayed = false;

    private void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (playOnlyOnce && hasPlayed)
            return;

        player = other.transform;
        hasPlayed = true;

        // Start the sound
        audioSource.Play();
    }

    private void Update()
    {
        // Follow the player while the sound is playing
        if (player != null && audioSource.isPlaying)
        {
            transform.position = player.position;
        }

        // Stop following when the sound is finished
        if (player != null && !audioSource.isPlaying)
        {
            player = null;
        }
    }
}