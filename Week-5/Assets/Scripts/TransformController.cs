using UnityEngine;

public class TransformController : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 moveDirection;

    public float rotateSpeed;
    public float scaleSpeed;

    private void Update()
    {
        transform.position += new Vector3(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed, moveDirection.z * moveSpeed);
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y + rotateSpeed, 0f);
        transform.localScale += Vector3.one * scaleSpeed;
    }
}
