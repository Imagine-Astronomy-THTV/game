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

    private bool triggered; // khi trap có th? b?t
    private bool active;    // khi trap có th? ho?t ??ng và gây sát th??ng

    private void Start()
    {
        // T? ??ng gán Animator và SpriteRenderer n?u chúng ch?a ???c gán
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();

        // Ki?m tra n?u không tìm th?y Animator ho?c SpriteRenderer
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
                // Ki?m tra n?u PlayerHealth không null tr??c khi g?i TakeDamage
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
            spriteRend.color = Color.red; // ??i màu ?? báo hi?u b?y s?p kích ho?t
        }

        yield return new WaitForSeconds(activationDelay); // Th?i gian tr??c khi kích ho?t

        if (spriteRend != null)
        {
            spriteRend.color = Color.white; // Tr? v? màu ban ??u
        }

        active = true;

        if (anim != null)
        {
            anim.SetBool("activated", true); // Kích ho?t animation
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
