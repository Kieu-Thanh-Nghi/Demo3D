using UnityEngine;

public class Player : Singleton<Player>
{
    public PlayerUi playerUi;
    public Transform PlayerFoot;
    public GameFlow gameFlow;

    [SerializeField] float zombieCurrentQuantity = 0;
    [SerializeField] GameObject WinUI, LostUI;

    public void SetZombieQuantity(int value)
    {
        zombieCurrentQuantity += value;
        if (zombieCurrentQuantity <= 0)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        WinUI.SetActive(true);
    }
}
