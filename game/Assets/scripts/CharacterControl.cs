using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public static float speed = 5f;
    public static float jumpSpeed = 8f;
    public static float gravity = 20f;
    private Vector3 moveDir = Vector3.zero;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDir = transform.TransformDirection(moveDir);
            moveDir = moveDir * speed;

            
        }

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            moveDir.y = jumpSpeed;
        }

        moveDir.y = moveDir.y - gravity * Time.deltaTime;

        controller.Move(moveDir * Time.deltaTime);
    }
}