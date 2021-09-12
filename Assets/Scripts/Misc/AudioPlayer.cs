using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;
    [SerializeField] Vector2 minMaxVolume;
    [SerializeField] Vector2 minMaxPitch;

    public void PlayAudio()
    {
        if (source == null || clip == null)
            return;
        float vol = Random.Range(minMaxVolume.x, minMaxVolume.y);
        float pitch = Random.Range(minMaxPitch.x, minMaxPitch.y);
        source.volume = vol;
        source.pitch = pitch;
        source.PlayOneShot(clip);
    }
}