using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterInput : MonoBehaviour
{

    public delegate void PingWithInfo(float inputTime, Action action);
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
            OnInput(i_conductor.CalculateSongPositionInBeats((float)AudioSettings.dspTime), Action.up);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            OnInput(i_conductor.CalculateSongPositionInBeats((float)AudioSettings.dspTime), Action.left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            OnInput(i_conductor.CalculateSongPositionInBeats((float)AudioSettings.dspTime), Action.right);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            OnInput(i_conductor.CalculateSongPositionInBeats((float)AudioSettings.dspTime), Action.down);
        }
    }
}

public enum Action
{ 
    up,
    down,
    left,
    right
}