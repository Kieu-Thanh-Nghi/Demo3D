using UnityEngine;
using UnityEngine.UI;

public class PhoneInputsUIContaner : MonoBehaviour
{
    [SerializeField] internal Joystick joystick;
    [SerializeField] internal RotateByDrag rotate;
    [SerializeField] internal bool isReload, isShoot;
    [SerializeField] internal int gunIndex;

    public void SetGunIndex(int i)
    {
        gunIndex = i;
    }
    internal void ResetGunIndex(bool isStop)
    {
        if (gunIndex != -1 && isStop)
        {
            gunIndex = -1;
        }
    }

    public void SetIsReload(bool val) => isReload = val;
    public void SetIsShoot(bool val) => isShoot = val;
}
