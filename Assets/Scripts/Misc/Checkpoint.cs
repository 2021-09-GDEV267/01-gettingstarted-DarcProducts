using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        PlayerDisable disable = other.GetComponent<PlayerDisable>();
        if (disable != null)
            disable.SetStartingPos(transform.position);
    }
}