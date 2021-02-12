using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float acceleration;
    [Space]
    public Vector2 input;
    public TMP_Text rewardText;
    [Space]
    public GameObject projectilePrefab;

    int _rewardCount = 0;
    Vector2 _direction;
    Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 newInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        input = Vector2.Lerp(input, newInput, Time.deltaTime * acceleration);

        if (Mathf.Abs(input.x) > 0.1f || Mathf.Abs(input.y) > 0.1f)
        {
            _direction.x = input.normalized.x;
            _direction.y = input.normalized.y;
        }

        _rb.velocity = input * moveSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
            SpawnProjectile();
    }

    public void TakeReward()
    {
        _rewardCount++;
        rewardText.text = _rewardCount.ToString();
    }

    private void SpawnProjectile()
    {
        Projectile projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Projectile>();
        projectile.direction = _direction;
    }
}
