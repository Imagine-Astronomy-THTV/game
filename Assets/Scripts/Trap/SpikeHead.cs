using UnityEngine;

public class SpikeHead : EnemyDamage
{
    [Header("SpikeHead Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;
    private Vector3 destination;// luu vi tri nguoi choi o bien nya
    private Vector3[] directions = new Vector3[4]; // chi co 4  
    private float checkTimer;
    private bool attacking;

    private void OnEnable()
    {
        Stop(); // STOP VA KO DI CHUYEN
    }
    private void Update()
    {
        if(attacking)
           transform.Translate(destination * Time.deltaTime * speed);
        else
        {
            checkTimer += Time.deltaTime;
            if (checkTimer > checkDelay)
                checkForPlayer();
        }
    }
    private void checkForPlayer()
    {
        CalculateDirection();

        // neu thay 4 huong
        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerLayer);
            if(hit.collider != null && !attacking)
            {
                attacking = true;
                destination = directions[i];
                checkTimer = 0;
            }
        }
    }
    private void CalculateDirection()
    {
        directions[0] = transform.right * range;
        directions[1] = -transform.right * range;
        directions[2] = transform.up * range;
        directions[2] = -transform.up * range;
    }
    private void Stop()
    {
        destination = transform.position; // dich den la vi tri hien tai thi se stop
        attacking = false;
    }

    private new void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision); // G?i ph??ng th?c c?a l?p cha n?u c?n
        Stop(); // D?ng khi va ch?m
    }


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    base.OnTriggerEnter2D(collision); //goi lai o ham cha
    //    //stop khi no cham vao vat gi do;
    //    Stop();
    //}
}
