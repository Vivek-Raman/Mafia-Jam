using UnityEngine;
using DG.Tweening;

public class Movement : MonoBehaviour
{

    private Transform t_beatSprite;
    private BeatMatchingManager i_beatMatch;

    // Start is called before the first frame update
    void Start()
    {
        t_beatSprite = this.transform;
        i_beatMatch = this.GetComponent<BeatMatchingManager>();

        i_beatMatch.OnValid += Move;
    }

    private void Move(Direction dir, float _)
    {
        switch (dir)
        {
            case Direction.up:

                t_beatSprite.DOMoveY(t_beatSprite.position.y + 1.0f, 0.1f);
                break;

            case Direction.down:

                t_beatSprite.DOMoveY(t_beatSprite.position.y - 1.0f, 0.1f);
                break;

            case Direction.left:

                t_beatSprite.DOMoveX(t_beatSprite.position.x - 1.0f, 0.1f);
                break;

            case Direction.right:

                t_beatSprite.DOMoveX(t_beatSprite.position.x + 1.0f, 0.1f);
                break;

        }
    }
}
