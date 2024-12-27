using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public GameObject winBackground; // Kéo UI Background vào ?ây trong Inspector
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
        Invoke("HideWinBackground", displayTime); // ?n background sau 3 giây
    }

    private void HideWinBackground()
    {
        winBackground.SetActive(false); // ?n background
    }
}
