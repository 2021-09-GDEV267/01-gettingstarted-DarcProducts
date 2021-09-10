using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSplit : MonoBehaviour
{
    [SerializeField] ObjectPooler playerPool;
    [SerializeField] GameObject mainPlayer;
    [SerializeField] float explosionForce;

    public void OnSpecial()
    {
            GameObject smallPlayer = playerPool.GetObject();
            smallPlayer.transform.localScale = Vector3.Scale(smallPlayer.transform.localScale, -(Vector3.one * .3f));
            smallPlayer.transform.position = mainPlayer.transform.position;
            smallPlayer.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, smallPlayer.transform.position, 3f);
            smallPlayer.GetComponent<PlayerController>().Speed *= 1.2f;
            smallPlayer.SetActive(true);
    }
}