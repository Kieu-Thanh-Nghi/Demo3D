using UnityEngine;

public class GunManager : CharacterUpdate
{
    [SerializeField] Character character;
    [SerializeField] Gun[] guns;
    int usingGunIndex;
    private void OnValidate()
    {
        character = GetComponent<Character>();
    }
    private void Awake()
    {
        usingGunIndex = 0;
        foreach (var gun in guns)
        {
            gun.character = character;
        }
    }

    internal Gun GetCurrentGun()
    {
        return guns[usingGunIndex];
    }
    public override void DoWhenUpdate(Character character)
    {
        guns[usingGunIndex].firingBullet(character);
        guns[usingGunIndex].ammo.GunReload(character);
        SwitchGun(character);
    }

    void SwitchGun(Character character)
    {
        for(int i = 0; i < guns.Length; i++)
        {
            if (character.inputs.isSwitchingGun(i))
            {
                SetActiveGun(i);
            }
        }
    }

    void SetActiveGun(int gunIndex)
    {
        guns[usingGunIndex].gameObject.SetActive(false);
        guns[gunIndex].gameObject.SetActive(true);
        usingGunIndex = gunIndex;
    }
}