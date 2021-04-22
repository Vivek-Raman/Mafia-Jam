using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using Cinemachine;

public class BeatTest : MonoBehaviour
{
    private Transform t_beatSprite;
    private Conductor i_conductor;
    private RegisterInput i_inputSource;
    private CinemachineImpulseSource i_impulseSource;

    private Vector3 c_origTransform;
    private Vector3 c_hitTransform;
    
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
    }

    private void RegisterInputTime(float inputTimeInBeats, Action action)
    {
        if (Mathf.Abs(inputTimeInBeats - Mathf.Round(i_conductor.SongPositionInBeats)) < .1f)
        {
            t_beatSprite.GetComponentInChildren<SpriteRenderer>().DOColor(Color.green, .04f);

            switch (action)
            {
                case Action.up:
                {
                    t_beatSprite.position += Vector3.up;
                    break;
                }
                case Action.down:
                    {
                        t_beatSprite.position += Vector3.down;
                        break;
                    }
                case Action.left:
                    {
                        t_beatSprite.position += Vector3.left;
                        break;
                    }
                case Action.right:
                    {
                        t_beatSprite.position += Vector3.right;
                        break;
                    }
            }
        }
        else
        {
            t_beatSprite.GetComponentInChildren<SpriteRenderer>().DOColor(Color.red, .04f);
            i_impulseSource.GenerateImpulse(Camera.main.transform.right);
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
