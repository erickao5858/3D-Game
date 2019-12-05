using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public SpriteAttributes attributes;
    private Camera mainCamera;
    public Animator animator;
    public float moveSpeed = 6.0f;
    public float jumpHeight = 6.0f;
    private float jumpHeightMultiplier = 1f;
    public float JumpLimit = 2f;
    #region HUD
    public SliderHandler HUDHealth, HUDStamina;
    #endregion
    void Start()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        if (characterController.isGrounded)
        {
            jumpHeightMultiplier = 1f;
        }
        //Debug.Log(gameObject.name + "," + gameObject.transform.position.y);
        if (Input.GetKeyDown("space") && gameObject.transform.position.y < JumpLimit)
        {
            if (HUDStamina == null || HUDStamina.Consume(50))
            {
                jumpHeightMultiplier = 1.5f;
            }
        }
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Walk", false);
            return;
        }
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, jumpHeight * jumpHeightMultiplier, Input.GetAxis("Vertical") * moveSpeed);
        characterController.Move(moveDirection * Time.deltaTime);
        animator.SetBool("Idle", false);
        animator.SetBool("Walk", true);
        mainCamera.transform.position = new Vector3(characterController.transform.position.x, mainCamera.transform.position.y, characterController.transform.position.z - 8);
    }
}
