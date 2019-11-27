using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Camera mainCamera;
    public Animator animator;
    public float speed = 6.0f;
    public float jumpSpeed = 6.0f;
    private Vector3 moveDirection = Vector3.zero;
    private float gravityMultiplier = 10;
    public GameObject pivot;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded)
        {
            jumpSpeed = 6;
            gravityMultiplier = 10;
        }
        if (Input.GetKeyDown("space"))
        {
            jumpSpeed = 12;
            gravityMultiplier = 20;
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * jumpSpeed, Input.GetAxis("Vertical") * speed);
        }
        Debug.Log("Direction:" + moveDirection + ", JumpSpeed: " + jumpSpeed + ", Gravity Multiplier: " + gravityMultiplier);
        if (moveDirection.y != 0)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Walk", false);
        }
        if (moveDirection.y > 0)
            moveDirection.y += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
        else moveDirection.y = 0;
        characterController.Move(moveDirection * Time.deltaTime);
        //if (Input.GetAxis("Horizontal") > 0)
        //    characterController.transform.RotateAround(new Vector3(characterController.transform.position.x, characterController.transform.position.y, characterController.transform.position.z - 20), Vector3.up, 30 * Time.deltaTime);
        //if (Input.GetAxis("Horizontal") < 0)
        //    characterController.transform.RotateAround(new Vector3(characterController.transform.position.x, characterController.transform.position.y, characterController.transform.position.z - 20), Vector3.up, -30 * Time.deltaTime);
        mainCamera.transform.position = new Vector3(characterController.transform.position.x, characterController.transform.position.y + 10f, characterController.transform.position.z - 8);
    }
}
