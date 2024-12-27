using UnityEngine;

public class BgScripts : MonoBehaviour
{
    public static BgScripts BgInstance; // Singleton instance
    public AudioSource Audio; // AudioSource component

    public bool IsMusicOn = true; // Tr?ng th�i nh?c (b?t/t?t)

    private void Awake()
    {
        // ??m b?o Singleton
        if (BgInstance != null && BgInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        BgInstance = this;
        DontDestroyOnLoad(this); // Kh�ng b? h?y khi chuy?n c?nh
    }

    private void Start()
    {
        Audio = GetComponent<AudioSource>();

        // ??m b?o nh?c kh�ng ph�t n?u tr?ng th�i l� t?t
        if (!IsMusicOn)
        {
            Audio.Stop();
        }
    }

    // H�m b?t nh?c
    public void PlayMusic()
    {
       
            Audio.mute = false;
        
    }

    // H�m t?t nh?c
    public void StopMusic()
    {
        
          Audio.mute = true;
        
    }
}
