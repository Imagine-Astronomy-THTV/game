using UnityEngine;
using UnityEngine.SceneManagement; 

public class UImanager : MonoBehaviour
{
    public static UImanager instance;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;
    
    private void Awake()
    {
        gameOverScreen.SetActive(false);
        instance = this;
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        SoundManager.instance.PlaySound(gameOverSound);
    }

    public void OnMenu() {
        MenuManager.instance.OnMenu();
    }
   
    public void Restart()
    {
        gameOverScreen.SetActive(false);
    }
   
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
