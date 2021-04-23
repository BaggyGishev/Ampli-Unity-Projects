using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    public Transform target;
    public float followSpeed;
    public float maxY, minY;

    private void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        Vector3 newPos = new Vector3(target.position.x, transform.position.y, -10f);

        float top = target.position.y + Camera.main.orthographicSize;
        float bottom = target.position.y - Camera.main.orthographicSize;

        if (top > maxY)
            newPos.y = maxY - Camera.main.orthographicSize;
        else if (bottom < minY)
            newPos.y = minY + Camera.main.orthographicSize;
        else
            newPos.y = target.position.y;

        transform.position = Vector3.Lerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}
