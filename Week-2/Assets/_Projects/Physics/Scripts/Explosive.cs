using UnityEngine;

public class Explosive : MonoBehaviour
{
    public float explosionRadius;
    public float pushForce;

    [ContextMenu("Boom!")]
    private void Explode()
    {
        if (!Application.isPlaying)
        {
            Debug.LogError("You must be in play mode to use 'Boom!'");
            return;
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(var coll in colliders)
        {
            if (coll.CompareTag("Block"))
            {
                var direction = coll.transform.position - transform.position;
                var distance = Mathf.Max(direction.magnitude, 1f);
                var rb = coll.GetComponent<Rigidbody>();
                rb.AddForce(direction.normalized * pushForce / distance / rb.mass, ForceMode.Impulse);
            }
        }

        Debug.Log("<color=red>Barrel was exploded!</color>");

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
