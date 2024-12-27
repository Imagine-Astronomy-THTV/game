using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

using UnityEngine.UI;

public class Health : MonoBehaviour
{
    
    //[SerializeField] private float startingHealth; // suc khoe khi bat dau
    //public float currentHealth { get;  private set; }
    private Animator anim;
    private bool dead;

    public float health;
    public float maxHealth;

    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;
    public PlayerHealth playerHealth;

    //private void Awake()
    //{
    //    health  = maxHealth;
    //    anim = GetComponent<Animator>();
    //}
    //public void TakeDamage(float _damage)

    //{
    //    health = Mathf.Clamp(health - _damage, 0, maxHealth);
    //    if (health > 0)
    //    {
    //        anim.SetTrigger("hurt");
    //        //ifreame
    //    }
    //    else
    //    {
    //        if (!dead)
    //        {
    //            anim.SetTrigger("die");
    //            GetComponent<PlayerMovement>().enabled = false; // ko the di chuyen neu bi chet
    //            dead = true;
    //        }

    //    }
    //}
    private void Update()
    {
        health = playerHealth.health;
        maxHealth = playerHealth.maxHealth;
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else hearts[i].sprite = emptyHeart;
            if (i < maxHealth)
            {
                hearts[i].enabled = true;

            }
            else hearts[i].enabled = false;

        }
    }
    
    
  



}
