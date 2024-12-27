using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Vector3 currentCheckPoint ;
    [SerializeField] private PlayerHealth playerHealth;

    private void Awake()
    {
        instance = this;

    }
    private void Start()
    {
        currentCheckPoint = playerHealth.transform.position;
    }
    public void Restart() {
        playerHealth.Respawn();
    }
    public void RePlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
