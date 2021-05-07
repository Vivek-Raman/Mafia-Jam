using UnityEngine;

namespace Temporary
{
public class TempMovement : MonoBehaviour
{
    [SerializeField] private float cellSize = 2f;
    
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            this.transform.position += cellSize * Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            this.transform.position += cellSize * Vector3.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.position += cellSize * Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            this.transform.position += cellSize * Vector3.right;
        }
    }
}
}