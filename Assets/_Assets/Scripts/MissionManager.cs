using System.Collections;
using TMPro;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    [SerializeField] GameFlow gameFlow;
    [SerializeField] int requiredKill;
    [SerializeField] TMP_Text missionText;
    [SerializeField] Gate gate;

    [SerializeField] int currentKill;
    [SerializeField] bool isPlayerExit;
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
        gate.OnPlayerEnter.AddListener(OnPlayerExit);
        yield return new WaitUntil(() => isPlayerExit);
        gate.OnPlayerEnter.RemoveListener(OnPlayerExit);
    }

    void OnPlayerExit() => isPlayerExit = true;


    public void OnZombieKilled(GameObject zombie) => currentKill++;
}