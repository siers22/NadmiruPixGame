using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public static float speed = 4f;
    public static float jumpSpeed = 8f;
    public static float gravity = 20f;
    private Vector3 moveDir = Vector3.zero;
    private CharacterController controller;
    [SerializeField] bool isInUncrouchableTrigger = false;

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

            if (Input.GetKey(KeyCode.LeftControl))
            {
                Crouch();
            }
            else
            {
                if (!isInUncrouchableTrigger)
                {
                    UnCrouch();
                }
                else Crouch();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            moveDir.y = jumpSpeed;
        }

        moveDir.y = moveDir.y - gravity * Time.deltaTime;

        controller.Move(moveDir * Time.deltaTime);
    }

    // Проверка на триггер неприседаемости
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "UnCrouchableTrigger")
        {
            isInUncrouchableTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "UnCrouchableTrigger")
        {
            isInUncrouchableTrigger = false;
        }
    }

    void Crouch()
    {
        controller.height = 1.2f;
        speed = 3.5f;
        jumpSpeed = 5.5f;
    }

    void UnCrouch()
    {
        controller.height = 2f;
        speed = 4f;
        jumpSpeed = 8f;
    }
}