using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float flySpeed;
    public Vector2 direction = Vector2.right;
    public LayerMask whatIsSolid;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        transform.Translate(direction * flySpeed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.forward, 0.25f, whatIsSolid);

        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                var enemies = FindObjectsOfType<Enemy>();
                if (enemies.Length == 1)
                    FindObjectOfType<Spawner>().SpawnChests();

                Destroy(hitInfo.collider.gameObject);
            }

            Destroy(gameObject);
        }
    }
}
