using UnityEngine;

public class Meow : MonoBehaviour
{
    public AudioClip[] meowSounds;

    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component attached to the button
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRandomMeow()
    {
        if (meowSounds.Length == 0)
        {
            Debug.LogWarning("No meow sounds assigned.");
            return;
        }

        // Generate a random index within the range of the meowSounds array
        int randomIndex = Random.Range(0, meowSounds.Length);

        // Play the randomly selected meow sound
        audioSource.PlayOneShot(meowSounds[randomIndex]);
    }
}
