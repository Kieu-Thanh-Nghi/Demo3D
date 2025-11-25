using System.Collections;
using TMPro;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    [SerializeField] GameFlow gameFlow;
    [SerializeField] int requiredKill;
    [SerializeField] TMP_Text missionText;
    [SerializeField] Transform exitDoor, playerFoot;

    [SerializeField] int currentKill;
    private void Start()
    {
        StartCoroutine(VerifyMission());
    }

    IEnumerator VerifyMission()
    {
        yield return VerifyZombieKill();
        yield return VerifyPlayerExit();

        gameFlow.OnMissionCompleted();
    }

    IEnumerator VerifyZombieKill()
    {
        currentKill = 0;
        missionText.text = $"Kill {requiredKill} zombie";
        yield return new WaitUntil(() => currentKill >= requiredKill);
    }

    IEnumerator VerifyPlayerExit()
    {
        missionText.text = $"Find exit door";
        yield return new WaitUntil(IsPlayerExit);
    }

    bool IsPlayerExit()
    {
        float distance = Vector3.Distance(playerFoot.position, exitDoor.position);
        return distance < 1;
    }

    public void OnZombieKilled(GameObject zombie) => currentKill++;
}