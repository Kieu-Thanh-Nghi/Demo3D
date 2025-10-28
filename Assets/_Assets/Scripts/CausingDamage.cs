using System.Collections.Generic;
using UnityEngine;

public class CausingDamage : MonoBehaviour
{
    [SerializeField] internal DamageType[] damageTypes; 
    public void DeliverDamage(Collider collider)
    {
        foreach(var type in damageTypes)
        {
            type.DoDamage(collider);
        }
    }
}

public abstract class DamageType : MonoBehaviour
{
    public abstract void ResetDealDame();
    public abstract void DoDamage(Collider collider);
}

public class OneTimeRagdollDamage : DamageType
{
    [SerializeField] int damage;
    List<Health> oldVictims = new();
    public override void DoDamage(Collider collider)
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
    }

    public override void ResetDealDame()
    {
        oldVictims.Clear();
    }
}

public class NormalDamage : DamageType
{
    [SerializeField] int damage;
    public override void DoDamage(Collider collider)
    {
        if (collider.CompareTag(TagID.Enemy))
        {
            collider.GetComponentInParent<Health>()?.TakeDamage(damage);
        }
    }

    public override void ResetDealDame(){}
}
