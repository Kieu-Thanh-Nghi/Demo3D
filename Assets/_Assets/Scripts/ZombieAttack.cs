using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] int damage;
    [SerializeField] Health playerHealth;

    public void StartAttack() => anim.SetBool(AnimID.AttackBool, true);
    public void StopAttack() => anim.SetBool(AnimID.AttackBool, false);
    public void OnAttack()
    {
        playerHealth.TakeDamage(damage);
    }
}
