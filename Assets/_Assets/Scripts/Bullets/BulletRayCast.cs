using UnityEngine;

public class BulletRayCast : MonoBehaviour
{
    [SerializeField] GameObject hitMarkerPrefab;
    [SerializeField] Gun theGun;
    Camera aimingCamera;
    [SerializeField] LayerMask layerMask;

    private void Start()
    {
        aimingCamera = theGun.Player.Cam;
    }
    public void PerformRayCasting()
    {
        Debug.Log("ss");
        Ray aimingRay = new Ray(aimingCamera.transform.position, aimingCamera.transform.forward);
        if(Physics.Raycast(aimingRay, out RaycastHit hitInfo, 1000f, layerMask))
        {
            Quaternion effectRotation = Quaternion.LookRotation(hitInfo.normal);
            Instantiate(hitMarkerPrefab, hitInfo.point, effectRotation);
        }
    }
}
