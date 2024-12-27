using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
     private Rigidbody2D body; // giup sua doi tu trong unity 
    [SerializeField]  private float speed;
    [SerializeField]  private float jumpPower;
    private Animator anim;
    private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private float wallJumpCooldown;
    private float horizontalInput;
    [SerializeField] private AudioClip jumpSound;


    [Header("Coyote Time")]
    [SerializeField] private float coyoteTime;
    private float coyoCounter;

    [SerializeField]private int extraJumps;
    private int jumpCounter;


    [SerializeField] private float wallJumpX;
    [SerializeField] private float wallJumpY;
    



    private void Awake() // moi khi chay 
    {
        body = GetComponent<Rigidbody2D>(); // lay thanh phan rigid vao player
        anim = GetComponent<Animator>(); // quyen truy cap vao
        boxCollider = GetComponent<BoxCollider2D>();
        
    }
    
    


    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        // X? lý l?t m?t nhân v?t
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        // C?p nh?t animation
        anim.SetBool("Run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        // jump hegith
        if (Input.GetKeyUp(KeyCode.Space) && body.linearVelocity.y > 0)
        {
            body.linearVelocity = new Vector2(body.linearVelocityX, body.linearVelocityY / 2);
        }
        if (onWall())
        {
            body.gravityScale = 0;
            body.linearVelocity = Vector2.zero;
        }
        else
        {
            body.gravityScale = 7;
            body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocityY);

            if (isGrounded())
            {
                coyoCounter = coyoteTime;
                jumpCounter = extraJumps;
            }
            else
                coyoCounter -= Time.deltaTime;
        }

    }

    private void Jump()
    {
        // counter less  0 va not on wall and no extra jump dont do anything
        if (coyoCounter < 0 && !onWall() && jumpCounter <= 0) return;
             SoundManager.instance.PlaySound(jumpSound);
        
        anim.SetTrigger("jump");

        if (onWall())
            WallJump();
        

        else
        {
            if (isGrounded())
                body.linearVelocity = new Vector2(body.linearVelocity.x, jumpPower);
            else
            {
                if (coyoCounter > 0)
                    body.linearVelocity = new Vector2(body.linearVelocity.x, jumpPower);
                else
                {
                    if (jumpCounter > 0)
                        body.linearVelocity = new Vector2(body.linearVelocity.x, jumpPower);
                        jumpCounter--;
                }
            }
            coyoCounter = 0;

        }

        //if (isGrounded())
        //{
        //    body.linearVelocity = new Vector2(body.linearVelocity.x, jumpPower);
        //    anim.SetTrigger("jump");
        //    SoundManager.instance.PlaySound(jumpSound);
        //}
        //else if (onWall() && !isGrounded())
        //{
        //    if (horizontalInput == 0)
        //    {
        //        body.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, jumpPower);
        //        transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        //    }
        //    else
        //    {
        //        body.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, jumpPower);
        //    }
        //    wallJumpCooldown = 0;
        //}
        
    }
    private void WallJump()
    {
        body.AddForce(new Vector2(-Mathf.Sign(transform.localScale.x) * wallJumpX, wallJumpY));
        wallJumpCooldown = 0;
    }





    private bool isGrounded() // kiem tra co phai tuong hay ko ?
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0 ,Vector2.down, 0.1f , groundLayer);
        return raycastHit.collider != null;

    }
    private bool onWall() // kiem tra co phai tuong hay ko ?
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x,0), 0.1f, wallLayer);
        return raycastHit.collider != null;

    }
    public bool canAttack()
    {
        Debug.Log("Can Attack: ");
        return horizontalInput == 0 && isGrounded() && !onWall();
    }



}

//private void Update()
//{
//    horizontalInput = Input.GetAxis("Horizontal");

//    // inputget axis lay chieu ngang xac dinh
//    //body.linearVelocityY : ko xoay truc y vaf z
//    if (horizontalInput > 0.01f)
//        transform.localScale = Vector3.one; // se bien thanh vector * one
//    // lat mat sang trai va phai ( -1 la trai )
//    // scale chi giup lat mat doi tuong
//    else if (horizontalInput < -0.01f)
//        transform.localScale = new Vector3(-1, 1, 1);


//    // duy tri toc do cung chieu ngang 


//    // set animator parameters
//    anim.SetBool("Run", horizontalInput != 0);
//    anim.SetBool("grounded", isGrounded());

//    // wall jump logic
//    if (wallJumpCooldown > 0.2f)
//    {

//        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocityY);


//        if (onWall() && !isGrounded())
//        {
//            body.gravityScale = 0;
//            body.linearVelocity = Vector2.zero;
//        }
//        else
//            body.gravityScale = 7;
//        if (Input.GetKey(KeyCode.Space) && isGrounded()) // neu nguoi choi o duoi mat dat
//            Jump();
//    }
//    else
//        wallJumpCooldown += Time.deltaTime;
//}

//private void Jump()
//{
//    if(isGrounded())
//    {
//        body.linearVelocity = new Vector2(body.linearVelocityX, jumpPower);
//        anim.SetTrigger("jump"); // trinh kich hoat nhay
//    }
//    else if(onWall() && !isGrounded())
//    {
//        if(horizontalInput == 0)
//        {
//            // di chuyen len voi toc do la 6 vi la truc x,y
//            body.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
//            transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);

//        }
//        else
//            body.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6); // di chuyen len voi toc do la 6 vi la truc x,y
//        wallJumpCooldown = 0; // giam hoi chieu ve con 0

//    }


//}
