using UnityEngine;

public class Chest : MonoBehaviour
{
    public bool isClosed;
    public Sprite openedChestSprite;
    [Space]
    public int rewardPercentage;
    public GameObject reward;

    SpriteRenderer _sr;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    void OpenChest()
    {
        isClosed = false;
        _sr.sprite = openedChestSprite;

        if (Random.Range(0f, 100f) < rewardPercentage)
            SpawnReward();
        else
        {
            var spawner = FindObjectOfType<Spawner>();
            spawner.DespawnChests();
            spawner.SpawnEnemies();
        }
    }

    void SpawnReward()
    {
        var position = transform.position + (Vector3.up / 2f);
        var rotation = Quaternion.identity;
        Instantiate(reward, position, rotation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isClosed && other.CompareTag("Player"))
            OpenChest();
    }
}
