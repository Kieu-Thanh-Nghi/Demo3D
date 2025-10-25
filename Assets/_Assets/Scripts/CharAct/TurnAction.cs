using UnityEngine;

public class TurnAction : CharacterUpdate
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

    internal Vector3 GetRotateAngle_Horizontal(Iinputs inputs, float anglePerSecond)
    {
        return new Vector3(0, inputs.GetRotateAxisHorizontal() * anglePerSecond * Time.deltaTime, 0);
    }
    internal Vector3 GetRotateAngle_Vertical(Iinputs inputs, float anglePerSecond)
    {
        return new Vector3(-inputs.GetRotateAxisVertical() * anglePerSecond * Time.deltaTime, 0, 0);
    }

    void TurnLeftRight(Transform characterTransform, Iinputs inputs, ConfigData configData)
    {
        TurnHorizontal(characterTransform,
            GetRotateAngle_Horizontal(inputs, configData.turnLeftRightSpeed_AnglePerSecond));
    }

    void TurnUpDown(Transform cameraHolder, Iinputs inputs, ConfigData configData)
    {
        TurnVertical(cameraHolder,
            GetRotateAngle_Vertical(inputs, configData.turnUpDownSpeed_AnglePerSecond),
            configData.minPitch, configData.maxPitch);
    }

    public override void DoWhenUpdate(Character character)
    {
        TurnLeftRight(character.transform, character.inputs, character.configData);
        TurnUpDown(character.cameraHolder, character.inputs, character.configData);
    }
}
