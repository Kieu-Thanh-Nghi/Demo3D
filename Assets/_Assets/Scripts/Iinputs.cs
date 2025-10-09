using UnityEngine;
public interface Iinputs
{
    float GetMoveAxisHorizontal();
    float GetMoveAxisVertical();
    float GetRotateAxisHorizontal();
    float GetRotateAxisVertical();
    bool isShootingBullet();
    bool isReloadAmmo();
}

public class ComputerInputs : Iinputs
{
    public float GetMoveAxisHorizontal() => Input.GetAxis(InputID.Horizontal);
    public float GetMoveAxisVertical() => Input.GetAxis(InputID.Vertical);
    public float GetRotateAxisHorizontal() => Input.GetAxis(InputID.AxisMouseX);
    public float GetRotateAxisVertical() => Input.GetAxis(InputID.AxisMouseY);

    public bool isReloadAmmo() => Input.GetKeyDown(KeyCode.R);

    public bool isShootingBullet() => Input.GetMouseButtonDown(InputID.LeftMouseButton);
}

public static class InputID
{
    public static string Horizontal = "Horizontal";
    public static string Vertical = "Vertical";
    public static string AxisMouseX = "Mouse X";
    public static string AxisMouseY = "Mouse Y";
    public static int LeftMouseButton = 0;
}

public static class AnimID
{
    public static string Shoot = "Shoot";
    public static string Reload = "Reload";
}
