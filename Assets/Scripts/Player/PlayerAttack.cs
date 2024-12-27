    using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    [SerializeField] private float attackCooldown; // tgian ban tiep theo
    [SerializeField] private Transform firePoint; // diem ma dan se ban
    [SerializeField] private GameObject[] fireballs; // 

    [SerializeField] private AudioClip fireballSound;

    private float cooldownTimer = Mathf.Infinity; // dem thgian hoi chieu
    private Animator anim;
    private PlayerMovement playerMovement;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        // CHUOT TRAI CO DUOC NHAN HAY KO ?
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
        {
            Debug.Log("Attack Triggered!");
            Attack();
            
        }
        

        cooldownTimer += Time.deltaTime;
    }
    private void Attack()
    {
        SoundManager.instance.PlaySound(fireballSound);
        // tao hoat anh
        anim.SetTrigger("attack");
        cooldownTimer = 0;
        fireballs[0].transform.position = firePoint.position;
        // sau khi ban ve lai vi tri dau tien

        fireballs[0].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
        // lay doi tuong qua cau lua va dat no theo huong mat cua player

    }
    protected int FindFireball()
    {
           for(int i = 0; i < fireballs.Length; i++)
           { 
            if (!fireballs[i].activeInHierarchy)
            {
                return i;
            }
           }
        return 0;
    }
  
}
