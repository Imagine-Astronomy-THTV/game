using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void LoadGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void GotosettingMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
    }
    public void GotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
