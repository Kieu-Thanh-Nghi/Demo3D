using UnityEngine;

public class TriggerZombieSpawner : MonoBehaviour
{
    [SerializeField] ZombieSpawner zombieSpawner;
    [SerializeField] bool isActive = true;
    private void OnTriggerEnter(Collider other)
    {
        if (!isActive) return;
        if (other.CompareTag("Player"))
        {
            zombieSpawner.StartSpawn();
            isActive = false;
        }
    }
}
