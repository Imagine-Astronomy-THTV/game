using UnityEngine;

public class Projectile : MonoBehaviour
{
    // tuan tu hoa//
    [SerializeField]private float speed;
    private bool hit;
    private float direction;

    private BoxCollider2D boxCollider;
    private Animator anim;

    private float lifetime;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.LogError("Animator không ???c tìm th?y trên GameObject " + gameObject.name);
        }
    }
    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);
        lifetime += Time.deltaTime;
        //if (lifetime > 5) gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        anim.SetTrigger("explode");

        if (collision.CompareTag("Enemy"))
        {
            PlayerHealth enemyHealth = collision.GetComponent<PlayerHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(1);
            }
            else
            {
                //Debug.LogWarning("Enemy không có component PlayerHealth!");
            }
        }
    }





    //private void OnTriggerEnter2D(Collider2D collision)
    //{

    //    hit = true;
    //    //boxCollider.enabled = false; // lam mat box coilider
    //    anim.SetTrigger("explode");
    //    if (collision.tag == "Enemy")
    //        collision.GetComponent<PlayerHealth>().TakeDamage(1);
    //}

    public void SetDirection( float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate() // vo hiue hoa
    {
        Debug.Log("Projectile Deactivated at position: " + transform.position);
        gameObject.SetActive(false);
    }
}
    