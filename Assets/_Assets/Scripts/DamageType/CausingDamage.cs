using UnityEngine;

public class CausingDamage : MonoBehaviour
{
    [SerializeField] internal DamageType[] damageTypes; 
    public void DeliverDamage(Collider collider, bool isDone = false)
    {
        foreach (var type in damageTypes)
        {
            type.DoDamage(collider, isDone);
        }
    }
}

public abstract class DamageType : MonoBehaviour
{
    public abstract void DoDamage(Collider collider, bool isDone);
}
