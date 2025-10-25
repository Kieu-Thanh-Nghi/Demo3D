using UnityEngine;

public class CausingDamage : MonoBehaviour
{
    [SerializeField] int damage;

    public void DeliverDamage(Collider collider)
    {
        if (collider.CompareTag(TagID.Enemy))
        {
            collider.GetComponent<Health>()?.TakeDamage(damage);
        }
    }
}
