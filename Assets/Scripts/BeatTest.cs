using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BeatTest : MonoBehaviour
{
    private Transform t_beatSprite;
    private Conductor i_conductor;

    private Vector3 c_origTransform;
    private Vector3 c_hitTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        i_conductor = FindObjectOfType<Conductor>();
        t_beatSprite = this.GetComponentInChildren<SpriteRenderer>().gameObject.transform;

        c_origTransform = transform.localScale;
        c_hitTransform = c_origTransform * 4.0f;

        i_conductor.OnBeat += BeatHit; 
    }

    // Update is called once per frame
    void Update()
    {
        t_beatSprite.DOScale(c_origTransform, .35f);
    }

    private void BeatHit()
    {
        t_beatSprite.DOScale(c_hitTransform, .04f);
    }
}
