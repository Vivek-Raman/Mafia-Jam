using UnityEngine;
using UnityEngine.InputSystem;

public class RegisterInput : MonoBehaviour
{

    [Tooltip("Account for Input Lag")]
    [SerializeField] private double inputLagOffset;

    public delegate void PingWithInfo(float inputTime, Direction action);
    //Send a ping to all events listening to this be@t
    public event PingWithInfo OnInput;

    private Conductor i_conductor;

    void Start()
    {
        i_conductor = FindObjectOfType<Conductor>();
    }

    public void OnUp(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
            OnInput(i_conductor.CalculateSongPositionInBeats(AudioSettings.dspTime, inputLagOffset), Direction.up);
    }

    public void OnLeft(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
            OnInput(i_conductor.CalculateSongPositionInBeats(AudioSettings.dspTime, inputLagOffset), Direction.left);
    }

    public void OnRight(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
            OnInput(i_conductor.CalculateSongPositionInBeats(AudioSettings.dspTime, inputLagOffset), Direction.right);
    }

    public void OnDown(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
            OnInput(i_conductor.CalculateSongPositionInBeats(AudioSettings.dspTime, inputLagOffset), Direction.down);
    }
}

public enum Direction
{ 
    up,
    down,
    left,
    right
}