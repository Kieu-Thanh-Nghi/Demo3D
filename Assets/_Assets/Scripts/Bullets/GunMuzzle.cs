using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMuzzle : MonoBehaviour
{
    [SerializeField] Transform muzzleImage;
    [SerializeField] float duration = 0.25f;
    // Start is called before the first frame update
    void Start() => HideMuzzle();

    public void ShowMuzzle()
    {
        muzzleImage.gameObject.SetActive(true);
        float Angle = Random.Range(0, 360f);
        muzzleImage.localEulerAngles = new Vector3(Angle, muzzleImage.localEulerAngles.y, muzzleImage.localEulerAngles.z);
        CancelInvoke();
        Invoke(nameof(HideMuzzle),duration);
    }

    void HideMuzzle()
    {
        muzzleImage.gameObject.SetActive(false);
    }
}
