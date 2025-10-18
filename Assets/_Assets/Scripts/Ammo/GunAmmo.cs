using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunAmmo : MonoBehaviour
{
    [SerializeField] int magSize = 6;
    [SerializeField] Gun theGun;
    [SerializeField] Animator anim;
    [SerializeField] AudioSource reloadSound;
    [SerializeField] int _loadedAmmo;
    [SerializeField] UnityEvent DoWhenLoadAmmo;

    private void Start()
    {
        Refill();
    }
    internal int LoadedAmmo
    {
        get => _loadedAmmo;
        set
        {
            _loadedAmmo = value;
            DoWhenLoadAmmo?.Invoke();
            if (_loadedAmmo <= 0) ReLoad();
            else UnLockShooting();
        }
    }
    public void ShootOneBullet() => LoadedAmmo--;
    void LockShooting() => theGun.isLocked = true;
    void UnLockShooting() => theGun.isLocked = false;
    public void Refill() => LoadedAmmo = magSize;
    internal void ReLoad()
    {
        anim.SetTrigger(AnimID.Reload);
        LockShooting();
    }

    public void PlayReloadSound() => reloadSound.Play();
}
