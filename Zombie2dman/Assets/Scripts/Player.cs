using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
     Rigidbody2D rb;
  float horizontal;
  public float speed;
  public float jumpPower;
  bool jumped, isWallJump;

  private bool canDash = true;
  private bool isDashing;
  private float dashingPower = 24f;
  private float dashingTime = 0.2f;
  private float dashingCooldown = 1f;
      private bool isFacingRight = true;
   [SerializeField] private TrailRenderer tr;


   public AudioSource mySfx;
   public AudioClip dashSfx;
  
  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }
  // Update is called once per frame
  void Update()
  {
        if (isDashing)
        {
            return;
        }
    
    if(Input.GetKeyDown(KeyCode.Space))
    {
      Jump();
      
    }
    if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
          {
            StartCoroutine(Dash());
            DashSound();
          }
    Flip();
    
  }
  private void FixedUpdate()
  {
            if (isDashing)
        {
            return;
        }
    horizontal = Input.GetAxisRaw("Horizontal");
    rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
  }
  void Jump()
  {
    if (!jumped)
    {
      rb.AddForce(new Vector2(0, jumpPower));
      jumped = true;
    }
  }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)  
           {
            jumped = false;
           }

           

           
    }

        private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

        private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

      public void DashSound()
    {
        mySfx.PlayOneShot(dashSfx);
    }




    

  
}
