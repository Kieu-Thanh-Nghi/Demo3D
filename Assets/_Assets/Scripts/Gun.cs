using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    [SerializeField] protected Transform firingPos;
    [SerializeField] protected AudioSource shootingSound;
    [SerializeField] protected Animator anim;
    [SerializeField] internal GunAmmo ammo;
    [SerializeField] internal bool isAutomaticShooting;
    [SerializeField] protected UnityEvent OnShoot;

    internal virtual void Launch()
    {
        anim.SetTrigger(AnimID.Shoot);
    }

    public virtual void PlayFireSound() => shootingSound.Play();
    
    public virtual void Shooting() => OnShoot?.Invoke();
    public virtual void Reload()
    {
        if (ammo.LoadedAmmo <= 0) return;
        firingPos.gameObject.SetActive(true);
    }
}
