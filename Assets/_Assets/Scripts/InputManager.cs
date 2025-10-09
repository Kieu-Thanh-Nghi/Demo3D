using UnityEngine;

public class InputManager
{
    internal ControlInputs controlInputs = new ControlInputs(new ComputerInputs());
    internal Iinputs inputs => controlInputs.inputs;
    internal void LockCursor(bool isLock)
    {
        if (isLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}

public class ControlInputs
{
    internal Iinputs inputs;
    public ControlInputs(Iinputs theInputs)
    {
        inputs = theInputs;
    }
    internal Vector3 GetMoveDirection(Transform charTransform)
    {
        float hInput = inputs.GetMoveAxisHorizontal();
        float vInput = inputs.GetMoveAxisVertical();
        return (charTransform.right * hInput + charTransform.forward * vInput).normalized;
    }

    internal Vector3 GetRotateAngle_Horizontal(float anglePerSecond)
    {
        return new Vector3(0, inputs.GetRotateAxisHorizontal() * anglePerSecond * Time.deltaTime, 0);
    }
    internal Vector3 GetRotateAngle_Vertical(float anglePerSecond)
    {
        return new Vector3(-inputs.GetRotateAxisVertical() * anglePerSecond * Time.deltaTime, 0, 0);
    }
}
