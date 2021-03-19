using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform target;
    public float followSpeed;
    public Vector3 offset;

    private void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, transform.position.y, target.position.z) + offset;
        transform.position = Vector3.Lerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}
