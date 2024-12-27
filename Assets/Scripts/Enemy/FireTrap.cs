using System.Collections;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [Header("Firetrap Timers")]
    [SerializeField] protected float activationDelay;
    [SerializeField] protected float activeTime;
    [SerializeField] protected float damage;
    protected Animator anim;
    protected SpriteRenderer spriteRend;

    private bool triggered; // khi trap c� th? b?t
    private bool active;    // khi trap c� th? ho?t ??ng v� g�y s�t th??ng

    private void Start()
    {
        // T? ??ng g�n Animator v� SpriteRenderer n?u ch�ng ch?a ???c g�n
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();

        // Ki?m tra n?u kh�ng t�m th?y Animator ho?c SpriteRenderer
        if (anim == null)
        {
            Debug.LogError("Animator component is missing on FireTrap.");
        }
        if (spriteRend == null)
        {
            Debug.LogError("SpriteRenderer component is missing on FireTrap.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!triggered)
            {
                StartCoroutine(ActiveFiretrap());
            }

            if (active)
            {
                // Ki?m tra n?u PlayerHealth kh�ng null tr??c khi g?i TakeDamage
                PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage);
                }
                else
                {
                    Debug.LogError("PlayerHealth component is missing on the player object.");
                }
            }
        }
    }

    private IEnumerator ActiveFiretrap()
    {
        triggered = true;

        if (spriteRend != null)
        {
            spriteRend.color = Color.red; // ??i m�u ?? b�o hi?u b?y s?p k�ch ho?t
        }

        yield return new WaitForSeconds(activationDelay); // Th?i gian tr??c khi k�ch ho?t

        if (spriteRend != null)
        {
            spriteRend.color = Color.white; // Tr? v? m�u ban ??u
        }

        active = true;

        if (anim != null)
        {
            anim.SetBool("activated", true); // K�ch ho?t animation
        }

        yield return new WaitForSeconds(activeTime); // Th?i gian b?y ho?t ??ng

        active = false;
        triggered = false;

        if (anim != null)
        {
            anim.SetBool("activated", false); // T?t animation
        }
    }
}
