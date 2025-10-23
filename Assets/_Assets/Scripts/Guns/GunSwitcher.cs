using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitcher : CharacterUpdate
{
    [SerializeField] GameObject[] guns;

    public override void CharUpdate()
    {
        for(int i = 0; i < guns.Length; i++)
        {
            
        }
    }
}

public abstract class CharacterUpdate : MonoBehaviour
{
    [SerializeField] protected CharActionUpdate charAction;
    abstract public void CharUpdate();
}
