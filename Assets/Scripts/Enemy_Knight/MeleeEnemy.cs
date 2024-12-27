using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]

    [SerializeField] private LayerMask playeLayer; 
    private float cooldownTimer = Mathf.Infinity; // tinh toan thoi gian tan cong
    private Animator anim;
    private PlayerHealth playerheath;
    private EnemyPatrol enemyPatrol;

    [SerializeField] private AudioClip attackSound;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>(); // lay trong thanh phan chu ko lay cua game
    }
    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if(PlayerInSight())
        {
            Debug.Log("test");
            if (cooldownTimer >= attackCooldown )
            {
                Debug.Log("Test _1");   
                cooldownTimer = 0;
                anim.SetTrigger("meleeAttack");
                SoundManager.instance.PlaySound(attackSound);
            }
        }
        if(enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center +
            transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playeLayer);

        if (hit.collider != null)
            playerheath = hit.transform.GetComponent<PlayerHealth>();
        return hit.collider != null;
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right
            * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
    
    private void DamagePlayer()
    {
        if(PlayerInSight())
        {
            playerheath.TakeDamage(damage);
        }
    }
}
