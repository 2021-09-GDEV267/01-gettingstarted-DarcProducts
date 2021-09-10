using UnityEngine;

public class PlayerDisable : MonoBehaviour
{
    [SerializeField] float minYValue;

    void LateUpdate()
    {
        float yValue = transform.position.y;
        if (yValue < minYValue)
            gameObject.SetActive(false);
    }
}