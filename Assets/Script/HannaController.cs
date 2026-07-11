using System.Collections;
using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HannaController : MonoBehaviour
{
    public bool isJumping = false;
    public float walkSpeed = 4.0f;
    public float gravity = 20.0f;
    public float jumpSpeed = 8.0f;
    private Vector3 velocity;
    private Animator animator;
    private CharacterController controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Idle", true);
        //animator.SetBool("Jumping", false);
        animator.speed = 2.0f;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isGrounded = controller.isGrounded;
        animator.SetBool("Grounded", isGrounded);

        if (!isJumping && Input.GetButtonDown("Jump"))
        {
            velocity.y = jumpSpeed;
            animator.SetTrigger("Jump");

            isJumping = true;

        }
        if (controller.isGrounded)
        {
            isJumping = false;
            velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            velocity *= walkSpeed;



            //else if (velocity.magnitude > 0.5)
            if (velocity.y < jumpSpeed && velocity.magnitude > 0.5)
            {
                animator.SetBool("Idle", false);
                transform.LookAt(transform.position + velocity);
            }
            else
            {
                animator.SetBool("Idle", true);
            }
        }
        velocity.y -= gravity * Time.deltaTime;
        //animator.SetFloat("Speed", velocity.magnitude);
        controller.Move(velocity * Time.deltaTime);
    }
}