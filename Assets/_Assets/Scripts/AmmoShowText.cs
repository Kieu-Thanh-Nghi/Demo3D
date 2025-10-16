using TMPro;
using UnityEngine;

public class AmmoShowText : MonoBehaviour
{
    [SerializeField] TMP_Text ammoText;
    [SerializeField] GunAmmo gunAmmo;
    
    public void ShowAmmo()
    {
        ammoText.text = gunAmmo.LoadedAmmo.ToString();
    }
}
