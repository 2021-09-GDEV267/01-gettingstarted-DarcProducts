using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Main/New Object Pooler")]
public class ObjectPooler : ScriptableObject
{
    [SerializeField] GameObject objectToPool;
    readonly List<GameObject> objectPool = new List<GameObject>(0);

    public GameObject GetObject()
    {
        if (objectPool.Count > 0)
            for (int i = 0; i < objectPool.Count; i++)
                if (!objectPool[i].activeSelf)
                    return objectPool[i];
        if (objectToPool != null)
        {
            GameObject newObject = Instantiate(objectToPool, Vector3.zero, Quaternion.identity);
            newObject.SetActive(false);
            objectPool.Add(newObject);
            return newObject;
        }
        else
        {
            Debug.LogWarning($"{this.name} has no prefab");
            return null;
        }
    }
}
