using System.Collections;
using UnityEditor;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] GameObject zombiePrefab;
    [SerializeField] int spawnQuantity;
    [SerializeField] float spawnInterval, radius;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = new Color(1, 0, 0, 0.1f);
        Handles.DrawSolidDisc(transform.position, transform.up, radius);
    }
#endif

    public void StartSpawn()
    {
        StartCoroutine(SpawnZombieByTime());
    }

    IEnumerator SpawnZombieByTime()
    {
        while (spawnQuantity > 0)
        {
            SpawnZombie();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnZombie()
    {
        Instantiate(zombiePrefab, transform.position, transform.rotation);
        spawnQuantity--;
    }
}
