using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private string sceneName = default;


    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(sceneName);
    }
}
