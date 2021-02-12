using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;

    Transform _target;

    private void Awake()
    {
        _target = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.position, Time.deltaTime * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
