using System.Collections;
using UnityEngine;

public class TurnOffAfterTime : MonoBehaviour
{
    [SerializeField] float turnOffTime;

    void OnEnable() => StartCoroutine(nameof(Deactivate));

    void OnDisable() => StopAllCoroutines();

    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(turnOffTime);
        gameObject.SetActive(false);
    }
}