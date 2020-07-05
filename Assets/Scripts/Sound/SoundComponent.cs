using UnityEngine;

public class SoundComponent : MonoBehaviour
{
    [SerializeField] AudioClip _audioClip = null;
    [SerializeField] AudioClip [] _audioClips = new AudioClip[0];
    
    public void PlaySound()
    {
        if (SoundPlayer.instance == null) return;
        if (_audioClip == null) return;

        SoundPlayer.instance.PlaySound(_audioClip);
    }

    public void PlaySoundClip(int index)
    {
        if (SoundPlayer.instance == null) return;
        if (index < 0 || index >= _audioClips.Length) return;
        if (_audioClips[index] == null) return;

        SoundPlayer.instance.PlaySound(_audioClips[index]);
    } 
}
