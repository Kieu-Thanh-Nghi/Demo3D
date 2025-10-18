using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float SecondsToDestroy;

    private void Start() => Destroy(gameObject, SecondsToDestroy);
}
