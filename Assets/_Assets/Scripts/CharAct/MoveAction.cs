using UnityEngine;

public class MoveAction : CharacterUpdate
{
    [SerializeField] CharacterController charCtrler;
    void Move(Iinputs inputs, CharacterData CharData, Transform charTransform)
    {
        charCtrler.SimpleMove(CharData.movingSpeed * GetMoveDirection(inputs, charTransform));
    }
    internal Vector3 GetMoveDirection(Iinputs inputs, Transform charTransform)
    {
        float hInput = inputs.GetMoveAxisHorizontal();
        float vInput = inputs.GetMoveAxisVertical();
        return (charTransform.right * hInput + charTransform.forward * vInput).normalized;
    }
    public override void DoWhenUpdate(Character character)
    {
        Move(character.inputs, character.CharData, character.transform);
    }
}
