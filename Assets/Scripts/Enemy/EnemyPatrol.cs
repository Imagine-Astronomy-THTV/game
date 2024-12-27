using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;

    private Vector3 initScale;
    private bool movingleft;

    [Header("Idel Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;



    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;


    private void Awake()
    {
        initScale = enemy.localScale;
        anim = enemy.GetComponent<Animator>();
        //anim = GetComponent<Animator>(); code cu
    }

    private void Update()
    {
        if (movingleft)
        {
            if (enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1); // Di chuy?n sang trái
            else
            {
                DirectionChange();  // ??i h??ng
            }
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x) // S?a ?i?u ki?n t? leftEdge thành rightEdge
                MoveInDirection(1);  // Di chuy?n sang ph?i
            else
            {
                DirectionChange();  // ??i h??ng
            }
        }
    }
    private void OnDisable()
    {
        //anim.SetBool("moving", false); 
            if (anim != null)
            {
                anim.SetBool("moving", false);
            }
        

    }


    private void DirectionChange()
    {
        anim.SetBool("moving", false);
        idleTimer += Time.deltaTime; 
        if(idleTimer > idleDuration)
        {
            movingleft = !movingleft;

        }
        
    }
    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("moving",true);
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);

        //move in that direction 
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y , enemy.position.z);
    }
}
