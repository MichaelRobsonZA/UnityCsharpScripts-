using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // The AudioSource component for sound effects
    private AudioSource soundEffectSource;

    // The AudioSource component for background music
    private AudioSource backgroundMusicSource;

    void Start()
    {
        // Get the AudioSource components attached to the Sound Manager game object
        AudioSource[] sources = GetComponents<AudioSource>();
        soundEffectSource = sources[0];
        backgroundMusicSource = sources[1];

        // Play background music
        backgroundMusicSource.Play();
    }

    // Play a sound effect
    public void PlaySoundEffect(AudioClip clip)
    {
        soundEffectSource.PlayOneShot(clip);
    }
}
