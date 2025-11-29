using UnityEngine;
using UnityEngine.UI;

public class PhoneInputsUIContaner : MonoBehaviour
{
    [SerializeField] internal Joystick joystick;
    [SerializeField] internal RotateByDrag rotate;
    [SerializeField] internal bool isReload, isShoot;
    [SerializeField] int gunIndex;

    public void SetGunIndex(int i)
    {
        gunIndex = i;
    }
    internal int GetGunIndex()
    {
        int temp = gunIndex;
        return temp;
    }

    public void SetIsReload(bool val) => isReload = val;
    public void SetIsShoot(bool val) => isShoot = val;
}
