using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCube : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private float moveInput; 
    private Rigidbody2D rb;

    private bool isGrounded;
    public Transform feetpos;
    public float checkRadius;
    public LayerMask whatisGround;

    public float fJumpPressedRemember = 0;//thời gian nhảy
    public float fJumpPressedRememberTime = 0.2f;
    public float fGroundedRemember = 0;//thời gian đừng dưới đất
    public float fGroundedRememberTime = 0.2f;

    InputController playerInput;

    //Get MoveController
    private MoveController m_MoveController;
    public MoveController MoveController
    {
        get
        {
            if (m_MoveController == null)
            {
                m_MoveController = gameObject.GetComponent<MoveController>();
            }
            return m_MoveController;
        }
    }



    private Animator anim;

    private void Awake()
    {
        playerInput = GameManager.Instance.InputController;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
   
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetpos.position, checkRadius, whatisGround);
        Jumping();
        MoveController.RotateBodyWithMouse();
    }

    private void FixedUpdate() => Movement();

    //Hàm di chuyển
    private void Movement()
    {
        Vector2 direction = new Vector2(playerInput.Horizontal * moveSpeed, rb.velocity.y);
        MoveController.Move(direction);
    }

    //Hàm để nhảy
    private void Jumping()
    {
        //nếu đứng dưới đất sẽ tính thời gian, để fix lỗi chạy quá ground k nhảy được
        fGroundedRemember -= Time.deltaTime;
        if(isGrounded == true)
        {
            fGroundedRemember = fGroundedRememberTime;
        }

        //nếu bấm nhảy  sẽ tính thời gian, để nhảy mượt hơn
        fJumpPressedRemember -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fJumpPressedRemember = fJumpPressedRememberTime;

        }

        if((fGroundedRemember > 0) && (fJumpPressedRemember > 0))
        {
            fJumpPressedRemember = 0;
            fGroundedRemember = 0;
            rb.velocity = Vector2.up * jumpForce;
        }
    }

  

  
}
