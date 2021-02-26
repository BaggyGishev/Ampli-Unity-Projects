using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;

    public void OnClick_ChangeScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void OnClick_Settings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void OnClick_ReturnToMain()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void OnClick_Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
