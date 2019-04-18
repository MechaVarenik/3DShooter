using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    // Скорость передвижения игрока
    [SerializeField] private float speed = 6.0f;
    [SerializeField] private float jumpForce = 8.0f;
    [SerializeField] private float gravity = 20.0f;

    private Vector3 moveDirection;
    private CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        moveDirection = Vector3.zero;

        cc.Move(PlayerVariable.playerPosition);
    }


    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 input = new Vector2(horizontal, vertical);
        Vector3 desiredMove = transform.forward * input.y + transform.right * input.x;
        moveDirection.x = desiredMove.x * speed;
        moveDirection.z = desiredMove.z * speed;
        cc.Move(moveDirection * Time.fixedDeltaTime);
        PlayerVariable.playerPosition = cc.transform.position;

        if (cc.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;

    }
 
}
