using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Rigidbody bulletPrefab;
    [SerializeField] Transform firingPos;
    [SerializeField] float bulletSpeed;
    [SerializeField] AudioSource shootingSound;
    [SerializeField] Animator anim;
    [SerializeField] internal GunAmmo ammo;

    internal void Launch()
    {
        anim.SetTrigger(AnimID.Shoot);
    }

    public void PlayFireSound() => shootingSound.Play();

    public void AddProjectile()
    {
        Rigidbody bullet = Instantiate(bulletPrefab, firingPos.position, firingPos.rotation);
        bullet.velocity = firingPos.right * bulletSpeed;
        firingPos.gameObject.SetActive(false);
    }
    public void Reload()
    {
        if (ammo.LoadedAmmo <= 0) return;
        firingPos.gameObject.SetActive(true);
    }
}
