using UnityEngine;
using UnityEngine.InputSystem;

public class BreakOut : MonoBehaviour
{
    public InputActionReference switchPositionAction;
    
    private Vector3 roomPosition;
    private Vector3 externalPosition = new Vector3(20f, 0f, 20f);
    private bool isInRoom = true;

    void Start()
    {
        roomPosition = transform.position;
        
        if (switchPositionAction != null)
        {
            switchPositionAction.action.Enable();
            switchPositionAction.action.performed += OnSwitchPosition;
        }
    }

    void OnSwitchPosition(InputAction.CallbackContext ctx)
    {
        if (isInRoom)
        {
            transform.position = externalPosition;
            isInRoom = false;
        }
        else
        {
            transform.position = roomPosition;
            isInRoom = true;
        }
    }

    void OnDestroy()
    {
        if (switchPositionAction != null)
        {
            switchPositionAction.action.performed -= OnSwitchPosition;
        }
    }
}
