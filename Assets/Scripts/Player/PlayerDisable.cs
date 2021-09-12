using UnityEngine;

public class PlayerDisable : MonoBehaviour
{
    [SerializeField] float minYValue;
    [SerializeField] bool resetPositionOnDisable;
    [SerializeField] Transform cameraRotater;
    Vector3 cameraRot;
    Vector3 startingPos;

    Rigidbody rb;

    void Awake() => rb = GetComponent<Rigidbody>();

    void Start()
    {
        if (cameraRotater != null)
            cameraRot = cameraRotater.eulerAngles;
        startingPos = transform.position;
    }

    void LateUpdate()
    {
        float yValue = transform.position.y;
        if (yValue < minYValue)
        {
            if (resetPositionOnDisable)
            {
                if (rb != null)
                {
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }
                if (cameraRotater != null)
                    cameraRotater.rotation = Quaternion.Euler(cameraRot);
                transform.position = startingPos;
                return;
            }
            gameObject.SetActive(false);
        }
    }
}