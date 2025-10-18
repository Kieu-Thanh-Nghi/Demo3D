using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    [SerializeField] internal CharActionUpdate Player;
    [SerializeField] protected AudioSource shootingSound;
    [SerializeField] protected Animator anim;
    [SerializeField] internal GunAmmo ammo;
    [SerializeField] internal bool isAutomaticShooting;
    [SerializeField] protected UnityEvent OnShoot;
    [SerializeField] protected UnityEvent DoWhenGunIdle;
    [SerializeField] internal bool isLocked;

    internal virtual void SetUpPlayer(CharActionUpdate thePlayer)
    {
        Player = thePlayer;
    }

    internal virtual void Launch()
    {
        if (isLocked) return;
        anim.SetTrigger(AnimID.Shoot);
    }

    public virtual void PlayFireSound() => shootingSound.Play();
    
    public virtual void Shooting() => OnShoot?.Invoke();
    public virtual void BackToIdle() => DoWhenGunIdle?.Invoke();
}
