using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform target;
    public Transform turret;
    public GameObject projectilePrefab;
    [Space]
    public float dstToShoot;
    public float shootDelay;
    public float shootForce;

    float _time;

    private void Start()
    {
        _time = shootDelay;
    }

    private void Update()
    {
        if (target == null)
            return;

        var direction = (target.position - transform.position).normalized;
        turret.rotation = Quaternion.LookRotation(direction);

        if (Vector3.Distance(target.position, transform.position) < dstToShoot)
        {
            _time -= Time.deltaTime;

            if (_time < 0f)
            {
                Shoot(direction);
                _time = shootDelay;
            }
        }
        else
            _time = shootDelay;
    }

    private void Shoot(Vector3 direction)
    {
        var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        var rb = projectile.GetComponent<Rigidbody>();

        rb.AddForce(direction * shootForce, ForceMode.Impulse);
    }
}
