using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dwarf : MonoBehaviour
{
    public int health = 3;
    public int money = 0;

    public TMP_Text moneyText;

    private void Update()
    {
        if (transform.position.y < -50f)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void TakeDamage()
    {
        health--;

        if (health <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Debug.Log($"Player was damaged! Now Dwarf has <color=red>{health} HP</color>");
    }

    public void GetMoney(int count)
    {
        money += count;
        moneyText.text = money.ToString();
    }
}
