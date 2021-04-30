using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    public Transform pathParent;
    public Transform startPathTrans;
    public Transform cameraTrans;

    public GameObject[] pathPrefabs;
    public float spawnXOffset;

    Transform _newPathTrans;
    Transform _oldPathTrans;

    private void Start()
    {
        _newPathTrans = startPathTrans;
    }

    private void Update()
    {
        if (cameraTrans.position.x > _newPathTrans.position.x)
        {
            GameObject randomPrefab = pathPrefabs[Random.Range(0, pathPrefabs.Length)];
            Vector3 newPos = new Vector3(_newPathTrans.position.x + spawnXOffset, _newPathTrans.position.y, _newPathTrans.position.z);

            if (_oldPathTrans != null)
                Destroy(_oldPathTrans.gameObject);

            _oldPathTrans = _newPathTrans;
            _newPathTrans = Instantiate(randomPrefab, newPos, Quaternion.identity, pathParent).transform;
        }
    }
}
