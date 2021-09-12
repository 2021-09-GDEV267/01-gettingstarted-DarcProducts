using UnityEngine;

public class PlayerScaling : MonoBehaviour
{
    [SerializeField] GlobalVector2Variable minMaxScale;
    [SerializeField] float shrinkRate;

    public void ShrinkPlayer()
    {
        Vector3 localScale = transform.localScale;
        float totalScale = localScale.x * localScale.y * localScale.z;
        Vector3 newScale = new Vector3(localScale.x - shrinkRate, localScale.y - shrinkRate, localScale.z - shrinkRate);

        if (totalScale > minMaxScale.Value.x)
            transform.localScale = newScale;
    }
}