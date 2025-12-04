using UnityEngine;
using UnityEngine.UI;

public class PhoneInputsUIContaner : MonoBehaviour
{
    [SerializeField] internal Joystick joystick;
    [SerializeField] internal RotateByDrag rotate;
    [SerializeField] GunManager gunManager;
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

    public void SetIsReload(bool val)
    {
        if(IsPlaying("reload", gunManager.GetCurrentGun().anim))
        {
            return;
        }
        isReload = val;
    }
    public void SetIsShoot(bool val)
    {
        if (IsPlaying("Fire", gunManager.GetCurrentGun().anim))
        {
            return;
        }
        isShoot = val;
    }

    bool IsPlaying(string stateName, Animator anim, int layer = 0)
    {
        AnimatorStateInfo current = anim.GetCurrentAnimatorStateInfo(layer);
        AnimatorStateInfo next = anim.GetNextAnimatorStateInfo(layer);

        return current.IsName(stateName) || next.IsName(stateName);
    }
}
