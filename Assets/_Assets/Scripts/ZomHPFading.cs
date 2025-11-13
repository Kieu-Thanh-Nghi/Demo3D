using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomHPFading : MonoBehaviour
{
    [SerializeField] AutoFade ZomHPAutoFade, ZomHPValueAutoFade;
    [SerializeField] Health ZomHealth;
    // Start is called before the first frame update
    void Start()
    {
        ZomHealth.OnHealthChange.AddListener(ShowZomHP);
    }

    void ShowZomHP(int a, int b)
    {
        ZomHPAutoFade.Show();
        ZomHPValueAutoFade.Show();
    }
}
