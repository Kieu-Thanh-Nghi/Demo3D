using UnityEngine;

public class Missile : CausingDamage
{
    [SerializeField] internal GameObject ExplosionPrefab;
    [SerializeField] internal float lifeTime = 20, explosionRadius, explosionForce;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        BlowObjects();
    }

    void BlowObjects()
    {
        Collider[] affectedObjects = Physics.OverlapSphere(transform.position, explosionRadius);
        int i;
        int n = affectedObjects.Length;
        for(i = 0; i < n - 1; i++)
        {
            Rigidbody rigidbody = affectedObjects[i].attachedRigidbody;
            if (rigidbody)
            {
                rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius, 1, ForceMode.Impulse);
            }
            DeliverDamage(affectedObjects[i]);
        }
        DeliverDamage(affectedObjects[n - 1], isDone: true);
    }
}
