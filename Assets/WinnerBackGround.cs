using UnityEngine;
using System.Collections;

public class GameOverWinner : MonoBehaviour
{
    public GameObject winnerBackground; // G�n background (GameObject) v�o ?�y trong Unity Editor
    public float displayTime = 3f; // Th?i gian hi?n th? background (gi�y)

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Ki?m tra va ch?m v?i player
        {
            StartCoroutine(ShowWinnerBackground());
        }
    }

    private IEnumerator ShowWinnerBackground()
    {
        winnerBackground.SetActive(true); // Hi?n th? background
        yield return new WaitForSeconds(displayTime); // Ch? v�i gi�y
        winnerBackground.SetActive(false); // T?t background
         // Quay v? menu
    }

 
}
