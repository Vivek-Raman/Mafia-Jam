using UnityEngine;
using UnityEngine.Events;

public class BeatMatchingManager : MonoBehaviour
{
    
    private Conductor i_conductor;
    private RegisterInput i_inputSource;
   
    public UnityAction<Direction, float> OnValid;

    public UnityAction<float> OnInvalid;
    
    // Start is called before the first frame update
    void Start()
    {
        i_conductor = FindObjectOfType<Conductor>();
        i_inputSource = FindObjectOfType<RegisterInput>();

        i_inputSource.OnInput += RegisterInputTime;
    }

    private void RegisterInputTime(float inputTimeInBeats, Direction dir)
    {
        float inaccuracy = Mathf.Abs(inputTimeInBeats - Mathf.Round(i_conductor.SongPositionInBeats));
        if (inaccuracy < .075f)
        {
            OnValid?.Invoke(dir, inaccuracy);
        }
        else
        {
            OnInvalid?.Invoke(inaccuracy);
        }
    }
}
