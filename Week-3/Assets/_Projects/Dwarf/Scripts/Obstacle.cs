using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("<color=red>Player died!</color>");
    }
}
