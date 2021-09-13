using System.Collections;
using UnityEngine;

public class EndingControl : MonoBehaviour
{
    [SerializeField] Transform playerT;
    [SerializeField] ObjectPooler objectPool;
    [SerializeField] float spawnDelay = 0;
    [SerializeField] int maxSpawns;
    int currentSpawns;

    public void InitializePoolSpawning() => StartCoroutine(nameof(StartSpawningPool));

    private void OnDisable() => StopAllCoroutines();

    IEnumerator StartSpawningPool()
    {
        if (currentSpawns < maxSpawns)
        {
            GameObject g = objectPool.GetObject();
            g.transform.SetPositionAndRotation(playerT.position + Vector3.up * 5, playerT.rotation);
            float newScale = Random.Range(.5f, 3f);
            g.transform.localScale = new Vector3(newScale, newScale, newScale);
            g.SetActive(true);
            currentSpawns++;
            yield return new WaitForSeconds(spawnDelay);
            StartCoroutine(nameof(StartSpawningPool));
        }
    }
}