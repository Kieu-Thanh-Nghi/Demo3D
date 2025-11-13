using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealthPoint;
    [SerializeField] UnityEvent onDie;
    public UnityEvent<int, int> OnHealthChange;

    int _healthPointValue;
    [SerializeField] int healthPoint
    {
        get => _healthPointValue;
        set
        {
            _healthPointValue = value;
            OnHealthChange?.Invoke(_healthPointValue, maxHealthPoint);
        }
    }
    bool IsDead => healthPoint <= 0;

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

    void Die() => onDie.Invoke();
}
