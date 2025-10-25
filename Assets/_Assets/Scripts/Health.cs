using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealthPoint;
    [SerializeField] Animator anim;

    int healthPoint;
    bool IsDead => healthPoint <= 0;

    private void OnValidate()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        healthPoint = maxHealthPoint;
    }

    public void TakeDamage(int damage)
    {
        if (IsDead) return;

        healthPoint -= damage;
        if (IsDead) Die();
    }

    void Die() => anim.SetTrigger(AnimID.DieTrigger);
}
