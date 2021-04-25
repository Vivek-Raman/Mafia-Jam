using UnityEngine;

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


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            OnInput(i_conductor.CalculateSongPositionInBeats(AudioSettings.dspTime, inputLagOffset), Direction.up);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            OnInput(i_conductor.CalculateSongPositionInBeats(AudioSettings.dspTime, inputLagOffset), Direction.left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            OnInput(i_conductor.CalculateSongPositionInBeats(AudioSettings.dspTime, inputLagOffset), Direction.right);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            OnInput(i_conductor.CalculateSongPositionInBeats(AudioSettings.dspTime, inputLagOffset), Direction.down);
        }
    }
}

public enum Direction
{ 
    up,
    down,
    left,
    right
}