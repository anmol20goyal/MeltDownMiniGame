using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region GameObjects

    private CharacterController charControl;
    private Animator charAnim;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;

    #endregion

    #region Variables

    private const float gravity = -20f;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private bool isJumping, isGrounded;
    [SerializeField] private float jumpSpeed = 3f;

    #endregion

    private void Awake()
    {
        isJumping = false;
        isGrounded = true;
        charControl = GetComponent<CharacterController>();
        charAnim = GetComponent<Animator>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        //Gizmos.DrawSphere(groundCheck.position, groundDistance);
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        charAnim.SetBool("isGrounded", true);
        charAnim.SetBool("isJumping", false);
        isJumping = false;

        // if freefall and sphere found the ground then set velocity.y = -2
        if (isGrounded && velocity.y < 0) velocity.y = -2f;


        var z = Input.GetAxis("Vertical");

        if ((Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) && isGrounded)
        {
            // sqrt is used to reduce the y component...otherwise player would blow up
            velocity.y = Mathf.Sqrt(jumpSpeed * -2f * gravity);

            charAnim.SetBool("isJumping", true);
            isJumping = true;
            charAnim.SetBool("isGrounded", false);
        }

        velocity.y += gravity * Time.deltaTime;
        charControl.Move(velocity * Time.deltaTime);

        if ((Input.GetKeyDown(KeyCode.C) || Input.GetMouseButtonDown(1)) && isGrounded)
        {
            charAnim.SetTrigger("Crouch");
            GetDown();
        }
    }

    public void GetDown()
    {
        charControl.height = 1;
        charControl.center = new Vector3(0, 0.5f, 0.25f);
    }

    public void GetUp()
    {
        charControl.height = 3;
        charControl.center = new Vector3(0, 1.5f, 0);
    }
}