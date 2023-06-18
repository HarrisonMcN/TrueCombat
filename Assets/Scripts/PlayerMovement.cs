using System.Collections;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [Header("Main")]
    public float baseSpeed;
    public float sprintSpeed;
    public float dodgeSpeed;
    public float dodgeTime;
    public Stamina stamina;

    [Header("Actions")]
    public bool sprinting;
    public bool isDodging;

    [Header("Misc")]
    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airSpeed;
    public float playerHeight;
    public Transform orientation;
    public GameObject playerBase;
    public GameObject playerDodge;
    public LayerMask whatIsGround;
    public bool readyToJump;
    public bool blocking;
    bool grounded;


    [Header("Keys")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode blockKey = KeyCode.Mouse1;
    public KeyCode dodgeKey = KeyCode.Space;

   



    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

       

        readyToJump = true;
        
    }

    private void Update()
    {
        
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        MyInput();
        SpeedControl();

        
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        //THIS ONE FOR SPRINTING
        if (Input.GetKeyDown(sprintKey) && !isDodging && grounded && stamina.currentStamina > 0)
        {
            baseSpeed = baseSpeed + sprintSpeed;

            sprinting = true;
        }

        if(stamina.currentStamina <= 0 && sprinting)
        {
            baseSpeed = baseSpeed - sprintSpeed;
            sprinting = false;
        }

        if (Input.GetKeyUp(sprintKey) && sprinting)
        {
            baseSpeed = baseSpeed - sprintSpeed;

            sprinting = false;
        }

        //THIS ONE FOR BLOCKING
        if (Input.GetKeyDown(blockKey))
        {
            blocking = true;
            readyToJump = false;
            
        }

        if (Input.GetKeyUp(blockKey))
        {
            blocking = false;
            readyToJump = true;
        }
        
        // THIS ONE FOR DODGE
        if (Input.GetKey(blockKey) && blocking)
        {
            if (Input.GetKeyDown(dodgeKey) && !isDodging && !sprinting && grounded && stamina.currentStamina > 0)
            {
                baseSpeed = baseSpeed + dodgeSpeed;
                isDodging = true;

                StartCoroutine(dodgeEye());
            }

            if (Input.GetKeyUp(dodgeKey) && isDodging && !grounded)
            {
                isDodging = false;

                StopCoroutine(dodgeEye());
                baseSpeed = baseSpeed - dodgeSpeed;
            }


        }

        if (isDodging)
        {
            playerBase.SetActive(false);
            playerDodge.SetActive(true);
        }
        else
        {
            playerBase.SetActive(true);
            playerDodge.SetActive(false);
        }

        playerDodge.transform.rotation = playerBase.transform.rotation;

        
    }

    IEnumerator dodgeEye()
    {
        yield return new WaitForSeconds(dodgeTime);

        baseSpeed = baseSpeed - dodgeSpeed;
        isDodging = false;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }

    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if(grounded)
            rb.AddForce(moveDirection.normalized * baseSpeed * 10f, ForceMode.Force);

        // in air
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * baseSpeed * 10f * airSpeed, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if(flatVel.magnitude > baseSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * baseSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }

   
}