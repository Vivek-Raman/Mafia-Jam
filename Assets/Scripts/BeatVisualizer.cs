using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class BeatVisualizer : MonoBehaviour
{
    private Transform t_beatSprite;
    private SpriteRenderer sr_beatSprite;
    private Conductor i_conductor;
    private CinemachineImpulseSource i_impulseSource;
    private BeatMatchingManager i_beatMatch;


    private Vector3 c_origTransform;
    private Vector3 c_hitTransform;



    // Start is called before the first frame update
    void Start()
    {
        t_beatSprite = this.GetComponentInChildren<SpriteRenderer>().gameObject.transform;
        sr_beatSprite = this.GetComponentInChildren<SpriteRenderer>();
        i_impulseSource = this.GetComponent<CinemachineImpulseSource>();
        i_beatMatch = this.GetComponent<BeatMatchingManager>();
        i_conductor = FindObjectOfType<Conductor>();

        c_origTransform = transform.localScale;
        c_hitTransform = c_origTransform * 4.0f;

        i_conductor.OnBeat += BeatHit;
        i_beatMatch.OnValid += VisualizeValidHit;
        i_beatMatch.OnInvalid += VisualizeInvalidHit;
    }

    // Update is called once per frame
    void Update()
    {
        sr_beatSprite.DOColor(Color.white, 3f);
        t_beatSprite.DOScale(c_origTransform, .35f);
    }

    private void BeatHit()
    {
        t_beatSprite.DOScale(c_hitTransform, .04f);
    }

    private void VisualizeValidHit(Direction _, float inaccuracy)
    { 
        sr_beatSprite.DOColor(Color.green, .04f);
    }

    private void VisualizeInvalidHit(float inaccuracy)
    {
        i_impulseSource.GenerateImpulse(Camera.main.transform.right);
        sr_beatSprite.DOColor(Color.red, .04f);
    }
}
