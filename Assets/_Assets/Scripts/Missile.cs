using UnityEngine;

public class Missile : MonoBehaviour
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
        foreach(var blowedObject in affectedObjects)
        {
            Rigidbody rigidbody = blowedObject.attachedRigidbody;
            if (rigidbody)
            {
                rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius, 1, ForceMode.Impulse);
            }
        }
    }
}
