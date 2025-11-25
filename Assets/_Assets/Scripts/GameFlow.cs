using UnityEngine;

public class GameFlow : MonoBehaviour
{
    [SerializeField] GameObject WinUI, LostUI;
    public void OnPlayerDie()
    {
        StopGame();
        LostUI.SetActive(true);
    }
    public void OnMissionCompleted()
    {
        StopGame();
        WinUI.SetActive(true);
    }

    void StopGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
