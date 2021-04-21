using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterInput : MonoBehaviour
{

    public delegate void PingWithInfo(float inputTime);
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnInput( i_conductor.CalculateSongPositionInBeats((float)AudioSettings.dspTime));
        }
    }
}
