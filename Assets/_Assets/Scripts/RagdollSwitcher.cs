using UnityEngine;

public class RagdollSwitcher : MonoBehaviour
{
    [SerializeField] Animator anim;
    public Rigidbody[] rigids;

    [ContextMenu("Retrieve Rigidbodies")]
    void RetrieveRigidbodies()
    {
        rigids = GetComponentsInChildren<Rigidbody>();
    }

    [ContextMenu("Clear Ragdoll")]
    void ClearRagdoll()
    {
        CharacterJoint[] joins = GetComponentsInChildren<CharacterJoint>();
        for (int i = 0; i < joins.Length; i++)
        {
            DestroyImmediate(joins[i]);
        }
        Rigidbody[] rigidList = GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < rigidList.Length; i++)
        {
            DestroyImmediate(rigidList[i]);
        }
        Collider[] colls = GetComponentsInChildren<Collider>();
        for (int i = 0; i < colls.Length; i++)
        {
            DestroyImmediate(colls[i]);
        }
    }

    [ContextMenu("Enable Ragdoll")]
    public void EnableRagdoll() => SetRagdoll(true);

    [ContextMenu("Disable Ragdoll")]
    public void DisableRagdoll() => SetRagdoll(false);

    void SetRagdoll(bool ragdollEnable)
    {
        anim.enabled = !ragdollEnable;
        for(int i = 0; i < rigids.Length; i++)
        {
            rigids[i].isKinematic = !ragdollEnable;
        }
    }
}
