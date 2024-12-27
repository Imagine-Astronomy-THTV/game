using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject gameOverObject;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            gameOverObject.SetActive(true);
        }
    }
}
