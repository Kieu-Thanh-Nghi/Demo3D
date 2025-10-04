using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CharActionUpdate : MonoBehaviour
{
    [SerializeField] CharacterController charCtrler;
    [SerializeField] internal CharacterData CharData;
    [SerializeField] internal InputManager Inputs = new();
    // Update is called once per frame
    void Update()
    {
        charCtrler.SimpleMove(CharData.movingSpeed * Inputs.MoveInput.GetDirection(transform));
    }
}

[Serializable]
public class CharacterData
{
    [SerializeField] internal float movingSpeed;
    [SerializeField] internal float turnSpeed_AnglePerSecond;
}