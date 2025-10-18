using TMPro;
using UnityEngine;

public class AmmoShowText : MonoBehaviour
{
    [SerializeField] TMP_Text ammoText;
    
    public void ShowAmmo(GunAmmo gunAmmo)
    {
        ammoText.text = gunAmmo.LoadedAmmo.ToString();
    }
}
