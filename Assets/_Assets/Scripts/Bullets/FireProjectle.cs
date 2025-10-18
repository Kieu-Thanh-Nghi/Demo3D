using UnityEngine;

public class FireProjectle : MonoBehaviour
{
    [SerializeField] protected Rigidbody bulletPrefab;
    [SerializeField] protected Transform firingPos;
    [SerializeField] protected float bulletSpeed;
    [SerializeField] internal GunAmmo ammo;
    public virtual void AddProjectile()
    {
        Rigidbody bullet = Instantiate(bulletPrefab, firingPos.position, firingPos.rotation);
        bullet.velocity = firingPos.right * bulletSpeed;
        firingPos.gameObject.SetActive(false);
    }

    public void ShowProjectile()
    {
        if (ammo.LoadedAmmo <= 0) return;
        firingPos.gameObject.SetActive(true);
    }
}
