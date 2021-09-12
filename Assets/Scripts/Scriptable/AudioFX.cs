using UnityEngine;

[CreateAssetMenu(menuName = "FX/New Audio FX")]
public class AudioFX : ScriptableObject
{
    [SerializeField] AudioClip clip;
    [SerializeField] Vector2 minMaxVolume;
    [SerializeField] Vector2 minMaxPitch;

    public void PlayFX(AudioSource source)
    {
        if (source != null && clip != null)
        {
            source.volume = Random.Range(minMaxVolume.x, minMaxVolume.y);
            source.pitch = Random.Range(minMaxPitch.x, minMaxPitch.y);
            source.PlayOneShot(clip);
        }
    }
}