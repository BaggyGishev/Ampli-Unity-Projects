using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject sounds;
    public GameObject music;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
            sounds.SetActive(!sounds.activeSelf);
        if (Input.GetKeyDown(KeyCode.M))
            music.SetActive(!music.activeSelf);
    }
}
