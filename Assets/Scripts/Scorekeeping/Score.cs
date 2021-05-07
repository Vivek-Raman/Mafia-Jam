using UnityEngine;
using UnityEngine.Events;

namespace Scorekeeping
{
public class Score : MonoBehaviour
{
    // we might need to double buffer the score
    //   +10 perfect hit
    //   - 5 wrong ingredient or something
    // collect this in one frame, and process it in the next frame
}
}