using UnityEngine;

public class AutomaticGun : Gun
{
    [SerializeField] int rpm;
    float lastShot, interval;

    private void Start()
    {
        interval = 60f / rpm;
        isAutomaticShooting = true;
    }

    void UpdateFiring()
    {
        Debug.Log(Time.time - lastShot >= interval);
        if (Time.time - lastShot >= interval)
        {
            anim.Play(AnimID.Shoot, layer: -1, normalizedTime: 0);
            lastShot = Time.time;
        }
    }

    internal override void Launch()
    {
        if (isLocked) return;
        UpdateFiring();
    }
}
