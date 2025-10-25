using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] CharacterUpdate[] updates;
    [SerializeField] internal Transform cameraHolder;
    [SerializeField] internal Camera Cam;
    [SerializeField] internal CharacterData CharData;
    [SerializeField] internal ConfigData configData;
    [SerializeField] internal bool isPause = false;
    internal Iinputs inputs = new ComputerInputs();

    // Update is called once per frame
    void Update()
    {
        if (isPause) return;
        foreach(var anUpdate in updates)
        {
            anUpdate.CharUpdate(this);
        }
    }
}

public abstract class CharacterUpdate : MonoBehaviour
{
    public void CharUpdate(Character character)
    {
        if(enabled) DoWhenUpdate(character);
    }

    abstract public void DoWhenUpdate(Character character);
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