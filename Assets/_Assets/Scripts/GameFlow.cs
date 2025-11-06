using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public void OnPlayerDie()
    {
        Debug.Log("PlayerDead");
    }

    public void OnZombieDie(Animator anim)
    {
        anim.SetTrigger(AnimID.DieTrigger);
    }
}
