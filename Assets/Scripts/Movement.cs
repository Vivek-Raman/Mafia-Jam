using UnityEngine;
using DG.Tweening;

public class Movement : MonoBehaviour
{
    [SerializeField] private float cellSize = 2f;
    [SerializeField] private float duration = 0.1f;

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

                t_beatSprite.DOMoveY(t_beatSprite.position.y + cellSize, duration);
                break;

            case Direction.down:

                t_beatSprite.DOMoveY(t_beatSprite.position.y - cellSize, duration);
                break;

            case Direction.left:

                t_beatSprite.DOMoveX(t_beatSprite.position.x - cellSize, duration);
                break;

            case Direction.right:

                t_beatSprite.DOMoveX(t_beatSprite.position.x + cellSize, duration);
                break;

        }
    }
}
