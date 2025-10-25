using UnityEngine;

public class LockCursorFeature : MonoBehaviour
{
    [SerializeField] Character character;

    private void OnValidate()
    {
        character = GetComponent<Character>();
    }
    private void Start()
    {
        LockCursor(true);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LockCursor(character.isPause);
            character.isPause = !character.isPause;
        }
    }
        internal void LockCursor(bool isLock)
    {
        if (isLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
