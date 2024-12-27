//using UnityEngine;

//public class RangedEnemy : MonoBehaviour
//{
//    [Header("Attack Parameters")]
//    [SerializeField] private float attackCooldown;
//    [SerializeField] private float range;
//    [SerializeField] private int damage;

//    [Header("Ranged Attack")]
//    [SerializeField] Transform firePoint;
//    [SerializeField] GameObject[] fireballs;


//    [Header("Collider Parameters")]
//    [SerializeField] private float colliderDistance;
//    [SerializeField] private BoxCollider2D boxCollider;

//    [Header("Player Layer")]
//    [SerializeField] private LayerMask playeLayer;
//    private float cooldownTimer = Mathf.Infinity; // tinh toan thoi gian tan cong

//    private Animator anim;
//    private EnemyPatrol enemyPatrol;

//    private void Awake()
//    {
//        anim = GetComponent<Animator>();
//        enemyPatrol = GetComponentInParent<EnemyPatrol>(); // lay trong thanh phan chu ko lay cua game
//    }
//    private void PlayerInSight()
//    {

//    }

//    private void Update()
//    {
//        cooldownTimer += Time.deltaTime;
//        if (PlayerInSight())
//        {
//            if (cooldownTimer >= attackCooldown)
//            {
//                cooldownTimer = 0;
//                anim.SetTrigger("rangedAttack");
//            }
//        }
//        if (enemyPatrol != null)
//        {
//            enemyPatrol.enabled = !PlayerInSight();
//        }
//    }

//    private void RangedAttack()
//    {
//        cooldownTimer = 0;
//        fireballs[FindFireball()].transform.position = transform.position;
//        fireballs[FindFireball()].GetComponent<EnemyProjectile>().ActivateProjectile();


//    }

//    private int FindFireball()
//    {
//        for (int i = 0; i < fireballs.Length; i++)
//        {
//            if (!fireballs[i].activeInHierarchy)
//            {
//                return i;
//            }
//        }
//        return 0;
//    }

//    private bool PlayerInSight();
    
//    private void OnDrawGizmos()
//    {
        
//    }




//}