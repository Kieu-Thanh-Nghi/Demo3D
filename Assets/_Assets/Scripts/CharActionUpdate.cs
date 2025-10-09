using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CharActionUpdate : MonoBehaviour
{
    [SerializeField] CharacterController charCtrler;
    [SerializeField] Transform cameraHolder;
    [SerializeField] internal CharacterData CharData;
    [SerializeField] internal ConfigData configData;
    [SerializeField] bool isPause = false;
    internal InputManager inputsManager = new();
    internal TurnAction charTurnAround = new();
    [SerializeField] internal Gun theGun;
    private void Start()
    {
        inputsManager.LockCursor(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inputsManager.LockCursor(isPause);
            isPause = !isPause;
        }
        if (isPause) return;
        Move();
        TurnLeftRight();
        TurnUpDown();
        firingBullet();
        GunReload();
    }

    void Move()
    {
        charCtrler.SimpleMove(CharData.movingSpeed * inputsManager.controlInputs.GetMoveDirection(transform));
    }

    void TurnLeftRight()
    {
        charTurnAround.TurnHorizontal(transform,
            inputsManager.controlInputs.GetRotateAngle_Horizontal(configData.turnLeftRightSpeed_AnglePerSecond));
    }

    void TurnUpDown()
    {
        charTurnAround.TurnVertical(cameraHolder,
            inputsManager.controlInputs.GetRotateAngle_Vertical(configData.turnUpDownSpeed_AnglePerSecond), 
            configData.minPitch, configData.maxPitch);
    }

    void firingBullet()
    {
        if (inputsManager.inputs.isShootingBullet())
        {
            theGun.Launch();
        }
    }

    void GunReload()
    {
        if (inputsManager.inputs.isReloadAmmo())
        {
            theGun.ammo.ReLoad();
        }
    }
}

public class TurnAction
{
    float pitch;
    internal void TurnHorizontal(Transform Character, Vector3 anglesPerSec)
    {
        Character.Rotate(anglesPerSec);
    }
    internal void TurnVertical(Transform Character, Vector3 anglesPecSec, float minPitch = -180, float  maxPitch = 180)
    {
        Vector3 angles = Character.localEulerAngles;
        pitch += anglesPecSec.x;
        //cameraHolder.Rotate(Inputs.RotateInput.GetUpDownAngle(configData.turnUpDownSpeed_AnglePerSecond));
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        angles.x = pitch;
        Character.localEulerAngles = angles;
    }
}

[Serializable]
public class CharacterData
{
    [SerializeField] internal float movingSpeed;
}

[Serializable]
public class ConfigData
{
    [Header("Turn Horizontal")]
    [SerializeField] internal float turnLeftRightSpeed_AnglePerSecond;

    [Header("Turn Vertical")]
    [SerializeField] internal float turnUpDownSpeed_AnglePerSecond;
    [SerializeField] internal float minPitch, maxPitch;
}