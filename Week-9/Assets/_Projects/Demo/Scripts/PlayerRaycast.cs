using TMPro;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public TMP_Text raycastableText;
    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, 25f))
        {
            if (hitInfo.collider.CompareTag("Raycastable"))
                raycastableText.text = hitInfo.collider.name;
            else
                raycastableText.text = string.Empty;
        }
    }
}
