using UnityEngine;

public class ReloadingSwitchGun : MonoBehaviour
{
    [SerializeField] GunAmmo gunAmmo;
    private void OnValidate()
    {
        gunAmmo = GetComponent<GunAmmo>();
    }
    private void OnEnable()
    {
        if(gunAmmo.LoadedAmmo <= 0)
        {
            gunAmmo.ReLoad();
        }
    }
}
