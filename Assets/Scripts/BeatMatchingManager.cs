using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using Cinemachine;
using UnityEngine.Events;

public class BeatMatchingManager : MonoBehaviour
{
    private Transform t_beatSprite;
    private Conductor i_conductor;
    private RegisterInput i_inputSource;
    private CinemachineImpulseSource i_impulseSource;

    private Vector3 c_origTransform;
    private Vector3 c_hitTransform;

    //public delegate void Ping(Direction dir);
    //public event Ping OnValid;
    public UnityAction<Direction, float> OnValid;

    public UnityAction<float> OnInvalid;
    
    // Start is called before the first frame update
    void Start()
    {
        i_conductor = FindObjectOfType<Conductor>();
        i_inputSource = FindObjectOfType<RegisterInput>();
        i_impulseSource = this.GetComponent<CinemachineImpulseSource>();
        t_beatSprite = this.GetComponentInChildren<SpriteRenderer>().gameObject.transform;

        c_origTransform = transform.localScale;
        c_hitTransform = c_origTransform * 4.0f;

        i_conductor.OnBeat += BeatHit;
        i_inputSource.OnInput += RegisterInputTime;
        this.OnValid += Movement;
    }

    private void RegisterInputTime(float inputTimeInBeats, Direction dir)
    {
        float inaccuracy = Mathf.Abs(inputTimeInBeats - Mathf.Round(i_conductor.SongPositionInBeats));
        if (inaccuracy < .075f)
        {
            t_beatSprite.GetComponentInChildren<SpriteRenderer>().DOColor(Color.green, .04f);
            OnValid?.Invoke(dir, inaccuracy);
        }
        else
        {
            t_beatSprite.GetComponentInChildren<SpriteRenderer>().DOColor(Color.red, .04f);
            i_impulseSource.GenerateImpulse(Camera.main.transform.right);
            OnInvalid?.Invoke(inaccuracy);
        }
    }

    private void Movement(Direction dir, float _)
    {
        switch (dir)
        {
            case Direction.up:

                t_beatSprite.position += Vector3.up;
                break;

            case Direction.down:

                t_beatSprite.position += Vector3.down;
                break;

            case Direction.left:

                t_beatSprite.position += Vector3.left;
                break;

            case Direction.right:

                t_beatSprite.position += Vector3.right;
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        t_beatSprite.GetComponentInChildren<SpriteRenderer>().DOColor(Color.white, 3f);
        t_beatSprite.DOScale(c_origTransform, .35f);
    }

    private void BeatHit()
    {
        t_beatSprite.DOScale(c_hitTransform, .04f);
    }
}
