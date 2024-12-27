using UnityEngine;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    public GameObject menu;
    public static MenuManager instance;
    [SerializeField] private Slider slider;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        menu.SetActive(false);
    }

    public void ChangeVolMusic() {
        SoundManager.instance.ChangeVol(slider.value);
    }

    public void OnMenu() { 
        menu.SetActive(true);
    }
}
