using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicCase : MonoBehaviour
{
    public TMP_Text toggleMusicTxt; // Text ?? hi?n th? tr?ng th�i nh?c

    private void Start()
    {
        // C?p nh?t giao di?n theo tr?ng th�i nh?c
        if (BgScripts.BgInstance.IsMusicOn)
        {
            toggleMusicTxt.text = "OFF MUSIC";
        }
        else
        {
            toggleMusicTxt.text = "ON MUSIC";
        }
    }

    public void MusicToggle()
    {
        // Ki?m tra tr?ng th�i nh?c v� th?c hi?n h�nh ??ng t??ng ?ng
        if (BgScripts.BgInstance.IsMusicOn)
        {
            BgScripts.BgInstance.StopMusic(); // T?t nh?c
            BgScripts.BgInstance.IsMusicOn = false; // C?p nh?t tr?ng th�i
            toggleMusicTxt.text = "ON MUSIC"; // C?p nh?t giao di?n
        }
        else
        {
            BgScripts.BgInstance.PlayMusic(); // B?t nh?c
            BgScripts.BgInstance.IsMusicOn = true; // C?p nh?t tr?ng th�i
            toggleMusicTxt.text = "OFF MUSIC"; // C?p nh?t giao di?n
        }
    }
}
