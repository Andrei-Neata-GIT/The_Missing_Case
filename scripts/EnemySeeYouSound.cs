using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemyProximitySound : MonoBehaviour
{
    [Header("Detection")]
    public Transform player;
    public float detectionDistance = 8f;

    [Header("Sound")]
    public AudioClip alertSound;

    [Header("Cooldown")]
    public float soundCooldown = 2f;

    private AudioSource audioSource;
    private bool playerWasInRange = false;
    private float lastSoundTime = -Mathf.Infinity;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }

    private void Update()
    {
        if (player == null)
            return;

        float distance = Vector3.Distance(transform.position, player.position);

        bool playerInRange = distance <= detectionDistance;

        // Player just entered the detection range
        if (playerInRange && !playerWasInRange)
        {
            if (alertSound != null && Time.time >= lastSoundTime + soundCooldown)
            {
                audioSource.PlayOneShot(alertSound);
                lastSoundTime = Time.time;
            }
        }

        playerWasInRange = playerInRange;
    }
}