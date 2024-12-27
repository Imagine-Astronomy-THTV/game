using UnityEngine;

public class EnemyProjectile : EnemyDamage // take dame eveyrtime
{
    [SerializeField]private float speed;
    [SerializeField] private float resertTime; // huy kich hoat doi tuong trong mot thoi gina
    private float lifetime;
    public float movementSpeed;

    private void OnDrawGizmosSelected()
    {
        Debug.Log(movementSpeed);
    }
    public void ActivateProjectile()
    {
        lifetime = 0;
        gameObject.SetActive(true);


    }
    private void Update()
    {
        movementSpeed = speed * Time.deltaTime;
        //transform.Translate(movementSpeed, 0, 0);
        transform.position = new Vector3 (transform.position.x, transform.position.y - movementSpeed,0);    
        lifetime += Time.deltaTime;
        if(lifetime > resertTime)
        {
            Destroy(gameObject);
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    base.OnTriggerEnter2D(collision);
    //    gameObject.SetActive(false);// khi cham vao gi do

    //}
}
