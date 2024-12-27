using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Animator anim;
    private bool dead;
    [Header("Health")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [SerializeField] private AudioClip deathSound;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public float health;
    public float maxHealth = 3;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float _damage)
    {
        health = Mathf.Clamp(health - _damage, 0, maxHealth);
        if (health > 0)
        {
            if (anim != null)
            {
                anim.SetTrigger("hurt");
            }
            StartCoroutine(Invunerability());
        }
        else
        {
            if (!dead)
            {
                if (anim != null)
                {
                    anim.SetTrigger("die");
                }

                PlayerMovement playerMovement = GetComponent<PlayerMovement>();
                if (playerMovement != null)
                {
                    playerMovement.enabled = false;
                }

                dead = true;
                SoundManager.instance.PlaySound(deathSound);
                UImanager.instance.GameOver();
            }
        }
    }
    public void AddHealth(float _value)
    {
        health = Mathf.Clamp(health + _value, 0, maxHealth);
    }

    public void Respawn()
    {
        transform.position = GameManager.instance.currentCheckPoint;
        dead = false;
        health = maxHealth;
        anim.Play("Idle");

        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.enabled = true;
        }

        Collider2D playerCollider = GetComponent<Collider2D>();
        if (playerCollider != null)
        {
            playerCollider.enabled = true;
        }

        StartCoroutine(Invunerability());
    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(11, 12, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(11, 12, false);
    }
}

//using System.Collections;
//using UnityEngine;

//public class PlayerHealth : MonoBehaviour
//{
//    private Animator anim;
//    private bool dead;
//    [Header("Health")]
//    [Header("iFreames")]
//    [SerializeField] private float iFrameDuration; // bat kha chien bai trong bao lau 
//    [SerializeField] private int numberOfFlashes; // nhay bao nhieu lan truoc khi die
//    private SpriteRenderer spriteRend;

//    [SerializeField] private AudioClip deathSound;



//    private void Awake()
//    {

//        anim = GetComponent<Animator>();
//        spriteRend = GetComponent<SpriteRenderer>();
//    }

//    public float health;
//    public float maxHealth = 3;
//    void Start()
//    {
//        health = maxHealth;

//    }
//    public void TakeDamage(float _damage)
//    {
//        health = Mathf.Clamp(health - _damage, 0, maxHealth);
//        if (health > 0)
//        {
//            if (anim != null)
//            {
//                anim.SetTrigger("hurt");
//            }
//            StartCoroutine(Invunerability());
//        }
//        else
//        {
//            if (!dead)
//            {

//                if (anim != null)
//                {
//                    anim.SetTrigger("die");
//                }

//                PlayerMovement playerMovement = GetComponent<PlayerMovement>();
//                if (playerMovement != null)
//                {
//                    playerMovement.enabled = false;
//                }

//                EnemyPatrol enemyPatrol = GetComponentInParent<EnemyPatrol>();
//                if (enemyPatrol != null)
//                {
//                    enemyPatrol.enabled = false;
//                }

//                MeleeEnemy meleeEnemy = GetComponent<MeleeEnemy>();
//                if (meleeEnemy != null)
//                {
//                    meleeEnemy.enabled = false;
//                }
//                Collider2D enemyCollider = GetComponent<Collider2D>();
//                if (enemyCollider != null)
//                {
//                    enemyCollider.enabled = false;
//                }

//                dead = true;
//                SoundManager.instance.PlaySound(deathSound);
//            }
//        }
//    }

//    public void AddHealth(float _value)
//    {
//        health = Mathf.Clamp(health + _value, 0, maxHealth);
//    }

//    public void Respawn()
//    {
//        dead = false;
//        health = maxHealth; 
//        anim.ResetTrigger("die");
//        anim.Play("Idle");

//        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
//        if (playerMovement != null)
//        {
//            playerMovement.enabled = true; 
//        }

//        Collider2D enemyCollider = GetComponent<Collider2D>();
//        if (enemyCollider != null)
//        {
//            enemyCollider.enabled = true; 
//        }

//        StartCoroutine(Invunerability());
//    }

//    private IEnumerator Invunerability()
//    {
//        Physics2D.IgnoreLayerCollision(11,12, true);
//        // nhan for tap 2 lan
//        for (int i = 0; i < numberOfFlashes; i++)
//        {
//            spriteRend.color = new Color(1, 0, 0, 0.5f);// chuyen tu mau do sang nhat 
//            yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes * 2));
//            spriteRend.color = Color.white;
//            yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes * 2));

//        }
//        //invunerabity // khoang bao lao het bat tu 
//        Physics2D.IgnoreLayerCollision(11, 12, false);
//    }

//}
