using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private AudioSource source;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
        source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip _sound)
    {
        
        source.PlayOneShot(_sound);
    }

    public void ChangeVol(float vol) {
        source.volume = vol; 
    }
}
