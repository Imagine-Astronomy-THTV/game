using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public GameObject winBackground; // K�o UI Background v�o ?�y trong Inspector
    private float displayTime = 5f; // Th?i gian hi?n th? background

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Cup"))
        {
            ShowWinBackground();
        }
    }

    private void ShowWinBackground()
    {
        winBackground.SetActive(true); // Hi?n th? background
        Invoke("HideWinBackground", displayTime); // ?n background sau 3 gi�y
    }

    private void HideWinBackground()
    {
        winBackground.SetActive(false); // ?n background
    }
}
