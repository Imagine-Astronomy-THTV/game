using UnityEngine;

public class BgScripts : MonoBehaviour
{
    public static BgScripts BgInstance; // Singleton instance
    public AudioSource Audio; // AudioSource component

    public bool IsMusicOn = true; // Tr?ng thái nh?c (b?t/t?t)

    private void Awake()
    {
        // ??m b?o Singleton
        if (BgInstance != null && BgInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        BgInstance = this;
        DontDestroyOnLoad(this); // Không b? h?y khi chuy?n c?nh
    }

    private void Start()
    {
        Audio = GetComponent<AudioSource>();

        // ??m b?o nh?c không phát n?u tr?ng thái là t?t
        if (!IsMusicOn)
        {
            Audio.Stop();
        }
    }

    // Hàm b?t nh?c
    public void PlayMusic()
    {
       
            Audio.mute = false;
        
    }

    // Hàm t?t nh?c
    public void StopMusic()
    {
        
          Audio.mute = true;
        
    }
}
