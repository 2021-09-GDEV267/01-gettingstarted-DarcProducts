using UnityEngine;

public class Collectable : MonoBehaviour, ICollectable
{
    [SerializeField] UIController ui;
    [SerializeField] AudioFX pickUpAudio;
    [SerializeField] AudioSource source;

    public void Collect()
    {
        if (pickUpAudio != null)
            pickUpAudio.PlayFX(source);
        if (ui != null)
            ui.CollectObject();
        gameObject.SetActive(false);
    }
}
