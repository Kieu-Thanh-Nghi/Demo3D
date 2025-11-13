using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUi : MonoBehaviour
{
    [SerializeField] AutoFade leftCratch, rightCratch;

    public void ShowLeftCratch() => leftCratch.Show();
    public void ShowRightCratch() => rightCratch.Show();
}
