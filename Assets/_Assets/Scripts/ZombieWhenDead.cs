using UnityEngine;

public class ZombieWhenDead : MonoBehaviour
{
    public void Minus1ZomQuatity()
    {
        Player.Instance.missionManager.OnZombieKilled(gameObject);
    }
}
