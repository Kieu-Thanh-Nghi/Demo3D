using UnityEngine;

public class NormalDamage : DamageType
{
    [SerializeField] int damage;
    public override void DoDamage(Collider collider, bool isDone)
    {
        if (collider.CompareTag(TagID.Enemy))
        {
            collider.GetComponentInParent<Health>()?.TakeDamage(damage);
        }
    }
}
