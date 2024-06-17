using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Singleton instance
    public static MusicManager instance;

    // Add your AudioClip field for music here
    public AudioClip backgroundMusic;

    // Reference to the AudioSource component
    public AudioSource audioSource;

    private void Awake()
    {
        // Ensure only one instance of MusicManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scene changes
        }
        else
        {
            // Destroy duplicate instances
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();

        // Set the background music clip and play it
        if (backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = true; // Loop the music
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No background music assigned to MusicManager.");
        }
    }
}
