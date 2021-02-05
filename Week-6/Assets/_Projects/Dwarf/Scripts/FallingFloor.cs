using UnityEngine;

public class FallingFloor : MonoBehaviour
{
    bool _isFalling = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!_isFalling)
        {
            _isFalling = true;
            GetComponent<Rigidbody>().useGravity = true;
            Invoke("DestroyFloor", 5f);

            Debug.Log("Floor is falling!");
        }
    }

    private void DestroyFloor()
    {
        Destroy(gameObject);
    }
}
