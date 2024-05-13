using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip walkSound;
    public AudioClip jumpSound;
    public AudioClip landSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayWalkSound()
    {
        audioSource.clip = walkSound;
        audioSource.Play();
    }

    public void PlayJumpSound()
    {
        audioSource.clip = jumpSound;
        audioSource.Play();
    }

    public void PlayLandSound()
    {
        audioSource.clip = landSound;
        audioSource.Play();
    }
}
