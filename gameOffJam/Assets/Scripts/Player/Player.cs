using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Static variables
    float jumpForceS_;

    
    #region movement
    float inputs;

    bool lookRight;
    public float speed;

    #endregion

    #region jump
    public float jumpForce;
    public float coyoteTime;
    [Range(0f,1f)]public float jumpCutSpeed;
    float groundTime;
    public float jumpBuffer;
    float lastJumpTime;
    bool isJumping;
    #endregion

    public int heightStatus;



    [Header("GroundAdjust")]
    public float groundCheckSize;
    public LayerMask groundLayer;

    BoxCollider2D box;
    Rigidbody2D rig_;

    #region encapsulamento
    public Rigidbody2D rig
    {
        get{return rig_;}
        set{rig_ = value;}
    }

    public float jumpForceS
    {
        get{return jumpForceS_;}
        set{jumpForceS_ = value;}
    }
    #endregion

    private void Awake() 
    {
        rig = GetComponent<Rigidbody2D>();
        box = GetComponentInChildren<BoxCollider2D>();
    }
    void Start()
    {
        jumpForceS = jumpForce;
        heightStatus = 1;
        lookRight = true;
    }

    private void Update() 
    {
        if(inputs != 0) turnLR(inputs > 0);

        if(Input.GetKeyDown(KeyCode.Space)) onJumpInput();

        if(Input.GetKeyUp(KeyCode.Space)) jumpCut();

        lastJumpTime -= Time.deltaTime;
        groundTime -= Time.deltaTime;
    }
    void FixedUpdate()
    {
        inputs = Input.GetAxisRaw("Horizontal");
        rig.velocity = new Vector2(inputs * speed * 100 *  Time.deltaTime, rig.velocity.y);

        if(onGrounded())
        {
            jumpForce = jumpForceS;
            isJumping = false;
        }

        if (canJump())
        {
            isJumping = true;
            jump();
        }
        
    }

    #region jump
    bool canJump()
    {
        if (groundTime > 0 && lastJumpTime > 0 && !isJumping) return true;
        else return false;
    }

    void jump()
    {
        groundTime = 0;
        lastJumpTime = 0;

        //caindo
        if (rig.velocity.y < 0)
        {
            jumpForce -= rig.velocity.y;
        }

        rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }


    void jumpCut()
    {
        if(rig.velocity.y > 0 && isJumping)
        {
            rig.AddForce((1- jumpCutSpeed) * rig.velocity.y * Vector2.down, ForceMode2D.Impulse);

            lastJumpTime = 0;
        }
    }
    void onJumpInput()
    {
        lastJumpTime = jumpBuffer;
    }

    #endregion
    public bool onGrounded()
    {   
        RaycastHit2D hitGround = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0, Vector2.down, groundCheckSize, groundLayer);
        if (hitGround)
        {
            groundTime = coyoteTime;
            return true;
        }
        return false;
    }

    void turn()
    {
        if(lookRight) transform.eulerAngles = new Vector2 (0,180);
        if(!lookRight) transform.eulerAngles = new Vector2 (0,0);
        lookRight = !lookRight;

    }


    void turnLR(bool input)
    {
        if(input != lookRight)
        {
            turn();
        }    
    }
}
