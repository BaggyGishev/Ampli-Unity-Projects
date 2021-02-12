using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] enemySpawners;
    public Transform[] chestSpawners;
    [Space]
    public GameObject enemyPrefab;
    public GameObject chestPrefab;

    List<GameObject> _chests = new List<GameObject>();

    private void Start()
    {
        SpawnChests();
    }

    public void SpawnChests()
    {
        DespawnChests();

        for (int i = 0; i < chestSpawners.Length; i++)
        {
            GameObject chest = Instantiate(chestPrefab, chestSpawners[i].position, Quaternion.identity);
            _chests.Add(chest);
        }
    }

    public void DespawnChests()
    {
        for (int i = 0; i < _chests.Count; i++)
            Destroy(_chests[i]);
    }

    public void SpawnEnemies()
    {
        for (int i = 0; i < enemySpawners.Length; i++)
        {
            Instantiate(enemyPrefab, enemySpawners[i].position, Quaternion.identity);
        }
    }
}
