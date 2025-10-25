using UnityEngine;
using UnityEngine.Events;

public class BulletRayCast : CausingDamage
{
    [SerializeField] GameObject hitMarkerPrefab;
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
            Quaternion effectRotation = Quaternion.LookRotation(hitInfo.normal);
            Instantiate(hitMarkerPrefab, hitInfo.point, effectRotation);
            DeliverDamage(hitInfo.collider);
        }
    }
}
