using UnityEngine;
public interface Iinputs
{
    float GetMoveAxisHorizontal();
    float GetMoveAxisVertical();
    float GetRotateAxisHorizontal();
    float GetRotateAxisVertical();
    bool isShootingBullet(bool isAutomatic);
    bool isReloadAmmo();
    bool isSwitchingGun(int i);
}

public class ComputerInputs : Iinputs
{
    public float GetMoveAxisHorizontal() => Input.GetAxis(InputID.Horizontal);
    public float GetMoveAxisVertical() => Input.GetAxis(InputID.Vertical);
    public float GetRotateAxisHorizontal() => Input.GetAxis(InputID.AxisMouseX);
    public float GetRotateAxisVertical() => Input.GetAxis(InputID.AxisMouseY);

    public bool isReloadAmmo() => Input.GetKeyDown(KeyCode.R);

    public bool isShootingBullet(bool isAutomatic)
    {
        if (isAutomatic)
        {
            return Input.GetMouseButton(InputID.LeftMouseButton);
        }
        else
        {
            return Input.GetMouseButtonDown(InputID.LeftMouseButton);
        }
    }

    public bool isSwitchingGun(int i)
    {
        return (Input.GetKeyDown(KeyCode.Alpha1 + i) || Input.GetKeyDown(KeyCode.Keypad1 + i));
    }
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
    public static string DieTrigger = "Die";
}
public static class TagID
{
    public static string Enemy = "Enemy";
}
