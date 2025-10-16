using UnityEngine;

public class FireProjectle : MonoBehaviour
{
    [SerializeField] protected Rigidbody bulletPrefab;
    [SerializeField] protected Transform firingPos;
    [SerializeField] protected float bulletSpeed;
    public virtual void AddProjectile()
    {
        Rigidbody bullet = Instantiate(bulletPrefab, firingPos.position, firingPos.rotation);
        bullet.velocity = firingPos.right * bulletSpeed;
        firingPos.gameObject.SetActive(false);
    }
}
