using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{

    #region referenced
    //Referenced from https://www.gamasutra.com/blogs/GrahamTattersall/20190515/342454/Coding_to_the_Beat__Under_the_Hood_of_a_Rhythm_Game_in_Unity.php 


    // << This might be better handled by a scriptable object >>

    //Song beats per minute
    //This is determined by the song you're trying to sync up to
    [SerializeField] private float songBpm;

    //The number of seconds for each song beat
    private float secPerBeat;

    //Current song position, in seconds
    private float songPosition;

    //Current song position, in beats
    private float songPositionInBeats;

    //How many seconds have passed since the song started
    private float dspSongTime;

    //an AudioSource attached to this GameObject that will play the music.
    private AudioSource musicSource;
    
    //The offset to the first beat of the song in seconds
    [SerializeField] private float firstBeatOffset;

    //the number of beats in each loop
    [SerializeField] private float beatsPerLoop;

    //the total number of loops completed since the looping clip first started
    private int completedLoops = 0;

    //The current position of the song within the loop in beats.
    private float loopPositionInBeats;
    #endregion

    private float beatTracker;


    public delegate void Ping();
    public event Ping OnBeat;

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

        beatTracker = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //determine how many seconds since the song started
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);

        //determine how many beats since the song started
        songPositionInBeats = songPosition / secPerBeat;

        //calculate the loop position
        if (songPositionInBeats >= (completedLoops + 1) * beatsPerLoop)
            completedLoops++;
        loopPositionInBeats = songPositionInBeats - completedLoops * beatsPerLoop;

        float beatDiff = songPositionInBeats - beatTracker;

        if (beatDiff < 0.05f && beatDiff > 0)
        {
            beatTracker = Mathf.Ceil(songPositionInBeats);
            OnBeat();
        }


    }
}
