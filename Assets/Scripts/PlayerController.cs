using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Movement Variables
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    float moveAcceleration = 500;
    [SerializeField]
    float maxSpeed = 500;
    [SerializeField]
    float jumpForce = 50;
    [SerializeField]
    float sensitivity = 5;

    [SerializeField]
    float health = 100;
    
    //Input systems
    InputAction moveAction;
    InputAction jumpAction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        Vector3 moveValue = new Vector3(moveInput.x, 0, moveInput.y);

        if (rb.linearVelocity.magnitude < maxSpeed) {
            rb.AddForce(transform.rotation*(moveAcceleration*Time.deltaTime*moveValue),ForceMode.Force);
        }

        //Jumping
        if (jumpAction.triggered && IsGrounded()) {
            rb.AddForce(jumpForce*Vector3.up,ForceMode.Impulse);
        }

        //Rotate to mouse
        float rotateHorizontal = Input.GetAxis("Mouse X");
		transform.Rotate(Vector3.up * rotateHorizontal * sensitivity, Space.Self);

    }


    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, transform.localScale.y + 0.1f);
    }


}
