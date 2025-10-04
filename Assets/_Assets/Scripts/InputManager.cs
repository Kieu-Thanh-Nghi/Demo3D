using UnityEngine;

public class InputManager
{
    internal MoveByKey MoveInput = new();
    internal RotateByMouse RotateInput = new();
}

public static class InputID
{
    public static string Horizontal = "Horizontal";
    public static string Vertical = "Vertical";
    public static string AxisMouseX = "Mouse X";
    public static string AxisMouseY = "Mouse Y";
}
public class MoveByKey
{
    internal Vector3 GetDirection(Transform charTransform)
    {
        float hInput = Input.GetAxis(InputID.Horizontal);
        float vInput = Input.GetAxis(InputID.Vertical);
        return (charTransform.right * hInput + charTransform.forward * vInput).normalized;
    }
}

public class RotateByMouse
{
    internal float GetLeftRightAngle(float anglePerSecond)
    {
        return Input.GetAxis(InputID.AxisMouseX) * anglePerSecond * Time.deltaTime;
    }
    internal float GetUpDownAngle(float anglePerSecond)
    {
        return Input.GetAxis(InputID.AxisMouseY) * anglePerSecond * Time.deltaTime;
    }
}
