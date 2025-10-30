using System.Collections.Generic;
using UnityEngine;

public class OneTimeRagdollDamage : DamageType
{
    [SerializeField] int damage;
    List<Health> oldVictims = new();
    public override void DoDamage(Collider collider, bool isDone)
    {
        if (collider.CompareTag(TagID.Enemy))
        {
            Health charHealth = collider.GetComponentInParent<Health>();
            if (!oldVictims.Contains(charHealth))
            {
                charHealth.TakeDamage(damage);
                oldVictims.Add(charHealth);
            }
        }
        if (isDone) ResetDealDame();
    }

    void ResetDealDame()
    {
        oldVictims.Clear();
    }
}
