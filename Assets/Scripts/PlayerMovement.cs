using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    bool isGrounded;

    public Transform checker;
    public float distance = 0.3f;
    private Vector3 velocity;
    public float speed;
    public float JumpHeight;
    public float Gravity;
    public LayerMask mask;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        #region movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        controller.Move(move* speed * Time.deltaTime);
        #endregion
        #region jump

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -3.0f * Gravity);
        }

        #endregion
        #region Gravity

        isGrounded = Physics.CheckSphere(checker.position, distance, mask);
        if (isGrounded && velocity.y <0 )
        {
            velocity.y = 0f;
        }
        velocity.y += Gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        #endregion
    }
}