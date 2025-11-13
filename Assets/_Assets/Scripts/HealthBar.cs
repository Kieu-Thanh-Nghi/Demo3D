using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] Image heathValImage;
    private void Start()
    {
        health.OnHealthChange.AddListener(SetHealthVal);
    }

    void SetHealthVal(int healthVal, int maxHealthPoint)
    {
        heathValImage.fillAmount = 1f * healthVal / maxHealthPoint;
    }
}
