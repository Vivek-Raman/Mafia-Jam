using UnityEngine;
using UnityEngine.Events;

namespace Scorekeeping
{
public class Score : MonoBehaviour
{
    // we might need to double buffer the score
    //   -10 wrong ingredient or something <priority>
    //   + 5 perfect hit
    // collect this in one frame, and process it in the next frame

    // track number of moves
    // track accuracy of each move
}
}