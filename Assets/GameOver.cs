using UnityEngine;
using UnityEngine.SceneManagement;  

public class GameOver : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
