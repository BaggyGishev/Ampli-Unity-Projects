using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject[] gems;

    private void OnMouseDown()
    {
        Instantiate(gems[Random.Range(0, gems.Length)], transform.position + Vector3.up * 2.5f, Quaternion.identity);
    }
}
