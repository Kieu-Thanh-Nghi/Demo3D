using UnityEngine;

public class Player : Singleton<Player>
{
    public PlayerUi playerUi;
    public Transform PlayerFoot;
    public GameFlow gameFlow;

    [SerializeField] internal MissionManager missionManager;
}
