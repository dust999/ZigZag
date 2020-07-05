using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    public static SoundPlayer instance = null;
    private AudioSource _audioSource = null;
   
    private void Awake()
    {
        instance = this;

        _audioSource = GetComponent<AudioSource>();
    }
    
    public void PlaySound(AudioClip _sound, float volume = 1f)
    {
        _audioSource.PlayOneShot(_sound, volume);
    }
}
