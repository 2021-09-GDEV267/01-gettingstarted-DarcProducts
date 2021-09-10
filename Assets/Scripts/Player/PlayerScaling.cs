using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScaling : MonoBehaviour
{
    [SerializeField] Vector2 minMaxScale;
    [SerializeField] float shrinkRate;
    [SerializeField] float growRate;

    public void ShrinkPlayer()
    {
        Vector3 localScale = transform.localScale;
        Vector3 newScale = new Vector3(localScale.x - shrinkRate, localScale.y - shrinkRate, localScale.z - shrinkRate);
        if (localScale.x + localScale.y + localScale.z - shrinkRate > minMaxScale.x)
            transform.localScale = newScale;
    }
}
