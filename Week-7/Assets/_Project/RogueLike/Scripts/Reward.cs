using UnityEngine;

public class Reward : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().TakeReward();
            Destroy(gameObject);
        }
    }
}
