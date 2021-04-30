using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed;

    private void Update()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
}
