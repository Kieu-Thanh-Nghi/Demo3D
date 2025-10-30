using UnityEngine;
using UnityEngine.Events;

public class BulletRayCast : CausingDamage
{
    [SerializeField] Gun theGun;
    Camera aimingCamera;
    [SerializeField] LayerMask layerMask;

    private void Start()
    {
        aimingCamera = theGun.character.Cam;
    }
    public void PerformRayCasting()
    {
        Ray aimingRay = new Ray(aimingCamera.transform.position, aimingCamera.transform.forward);
        if(Physics.Raycast(aimingRay, out RaycastHit hitInfo, 1000f, layerMask))
        {
            ShowHitSurface(hitInfo);
            DeliverDamage(hitInfo.collider);
        }
    }

    void ShowHitSurface(RaycastHit hitInfo)
    {
        HitSurface hitSurface = hitInfo.collider.GetComponent<HitSurface>();
        if(hitSurface != null)
        {
            GameObject effPrefab = HitEffectManager.Instance.GetEffectPrefab(hitSurface.surfaceType);
            if(effPrefab != null)
            {
                Quaternion effectRotation = Quaternion.LookRotation(hitInfo.normal);
                Instantiate(effPrefab, hitInfo.point, effectRotation);
            }
        }
    }
}
