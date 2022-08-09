using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AjPlayer : MonoBehaviour
{
    public float runSpeed = 5;
    public float runWalkSpeed = 100;
    public float rotationSpeed = 200;
    public Animator animator;
    private float x, y;
    public float gravity = 9.8f;
    public CharacterController player;
    public float fallVelocity;
    public float fuerza_salto = 0.5f;
    private Vector3 playerInput;
    public Camera mainCamera;
    private Vector3 camFoorward;
    private Vector3 CamRight;
    private Vector3 movePlayer;
    public float jumpForce;
    //public GameObject image;


    // Update is called once per frame
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = -1;
        player = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        //image.SetActive(true);
        //StartCoroutine("time_starts");        
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");


        playerInput = new Vector3(x, 0, y);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);
        animator.SetFloat("VetX", playerInput.magnitude * runSpeed);

        camDirection();

        movePlayer = playerInput.x * CamRight + playerInput.z * camFoorward;
        /* Checking if the player is moving and if the left shift key is pressed. If the player is
        moving and the left shift key is pressed, it will call the Run() function. If the player is
        moving and the left shift key is not pressed, it will set the movePlayer variable to the
        movePlayer variable multiplied by the runSpeed variable. */
        if (playerInput != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            movePlayer = movePlayer * runSpeed;
        }
        else if (playerInput != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            Run();
        }
        player.transform.LookAt(player.transform.position + movePlayer);

        SetGravity();
        PlayerSkills();

        player.Move(movePlayer * Time.deltaTime);
    }


    /// <summary>
    /// If the player is grounded and the jump button is pressed, then the player will jump
    /// </summary>
    void PlayerSkills()
    {
        if (player.isGrounded && Input.GetButtonDown("Jump"))
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;
            animator.SetTrigger("IsJump");
        }
    }

    /// <summary>
    /// It gets the forward and right vectors of the camera and sets the y value to 0
    /// </summary>
    void camDirection()
    {
        camFoorward = mainCamera.transform.forward;
        CamRight = mainCamera.transform.right;

        camFoorward.y = 0;
        CamRight.y = 0;

        camFoorward = camFoorward.normalized;
        CamRight = CamRight.normalized;

    }

    /// <summary>
    /// If the player is grounded, then the fall velocity is set to the negative of the gravity
    /// multiplied by the time since the last frame
    /// </summary>
    void SetGravity()
    {
        if (player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
            animator.SetFloat("VetY", player.velocity.y);
        }
        animator.SetBool("IsGround", player.isGrounded);

    }
    private void OnAnimatorMove()
    {

    }
    /// <summary>
    /// The function Run() is called when the player presses the left shift key. The function then
    /// multiplies the movePlayer variable by the runWalkSpeed variable. The animator.SetFloat()
    /// function is then called to set the animation speed to the magnitude of the playerInput variable
    /// multiplied by the runWalkSpeed variable
    /// </summary>
    void Run()
    {
        movePlayer = movePlayer * runWalkSpeed;
        animator.SetFloat("VetX", playerInput.magnitude * runWalkSpeed);
    }

}
