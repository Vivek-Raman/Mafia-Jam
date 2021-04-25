using UnityEngine;
using UnityEngine.Events;

public class Conductor : MonoBehaviour
{

    #region referenced
    //Referenced from https://www.gamasutra.com/blogs/GrahamTattersall/20190515/342454/Coding_to_the_Beat__Under_the_Hood_of_a_Rhythm_Game_in_Unity.php 


    // << This might be better handled by a scriptable object >>

    //Song beats per minute
    [Tooltip("This is determined by the song you're trying to sync up to")]
    [SerializeField] private float songBpm;

    //The number of seconds for each song beat
    private float secPerBeat;

    //Current song position, in seconds
    private float songPosition;

    //Current song position, in beats
    private float songPositionInBeats;
    public float SongPositionInBeats { get { return songPositionInBeats; } }

    //How many seconds have passed since the song started
    private float dspSongTime;

    //an AudioSource attached to this GameObject that will play the music.
    private AudioSource musicSource;
    
    [Tooltip("The offset to the first beat of the song in seconds")]
    [SerializeField] private float firstBeatOffset;

    [Tooltip("the number of beats in each loop")]
    [SerializeField] private float beatsPerLoop;

    //the total number of loops completed since the looping clip first started
    private int completedLoops = 0;

    //The current position of the song within the loop in beats.
    private float loopPositionInBeats;
    #endregion

    //Tracks the next beat to keep account of 
    private float beatTracker;

 
    //Send a ping to all events listening to this be@t
    public UnityAction OnBeat;

    void Start()
    {
        //Load the AudioSource attached to the Conductor GameObject
        musicSource = GetComponent<AudioSource>();

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        //Start the music
        musicSource.Play();

        //The first beat to look out for
        beatTracker = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);

        //determine how many beats since the song started
        songPositionInBeats = (songPosition / secPerBeat) + 1f;

        //calculate the loop position
        if (songPositionInBeats >= ((completedLoops + 1) * beatsPerLoop) + 1)
            completedLoops++;
        loopPositionInBeats = songPositionInBeats - completedLoops * beatsPerLoop;

        //Calculate the difference between currect position in beats and next tracked beat
        float beatDiff = songPositionInBeats - beatTracker;

        //if difference is positive, a new beat is registered
        if (beatDiff > 0)
        {
            //next beat tracked
            beatTracker = Mathf.Ceil(songPositionInBeats);
            //Ping everyone listening for a beat
            OnBeat?.Invoke();
        }


    }

    public float CalculateSongPosition(double dspTime)
    {
        //determine how many seconds since the song started
         return (float)(dspTime - dspSongTime - firstBeatOffset );
    }

    public float CalculateSongPosition(double dspTime, double inputLag)
    {
        //determine how many seconds since the song started
        return (float)(dspTime - dspSongTime - firstBeatOffset - inputLag);
    }

    public float CalculateSongPositionInBeats(double dspTime)
    {
        //determine how many seconds since the song started
        return ((float)((dspTime - dspSongTime - firstBeatOffset)) / secPerBeat ) + 1f;
    }

    public float CalculateSongPositionInBeats(double dspTime, double inputLag)
    {
        //determine how many seconds since the song started
        return ((float)((dspTime - dspSongTime - firstBeatOffset - inputLag)) / secPerBeat) + 1f;
    }


}
